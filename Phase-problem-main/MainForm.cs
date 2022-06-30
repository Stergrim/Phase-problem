
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;

using cPoint3D            = Plot3D.Graph3D.cPoint3D;
using eRaster             = Plot3D.Graph3D.eRaster;
using eNormalize          = Plot3D.Graph3D.eNormalize;
using eSchema             = Plot3D.ColorSchema.eSchema;

namespace Phase_problem_main
{
    using Plot3D;
    using System.ComponentModel;

    public partial class MainForm : Form
    {
        public int NumberCoefficients { get; set; }
        public int DiscretizationPupil { get; set; }
        public double[] CoefficientsPolynomials { get; set; }

        public MainForm()
        {
            InitializeComponent();
            NumberCoefficients = 10;
            DiscretizationPupil = 51;
            SetDefaultCoeff();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            comboRaster.Sorted = false;
            foreach (eRaster e_Raster in Enum.GetValues(typeof(eRaster)))
            {
                comboRaster.Items.Add(e_Raster);
            }
            comboRaster.SelectedIndex = (int)eRaster.Labels;

            comboColors.Sorted = false;
            foreach (eSchema e_Schema in Enum.GetValues(typeof(eSchema)))
            {
                comboColors.Items.Add(e_Schema);
            }
            comboColors.SelectedIndex = (int)eSchema.Rainbow2;

            DefSurfaceZernike(); // set "DefSurfaceZernike" OnLoad
            comboDataSrc.SelectedIndex = 0;
        }

        private void comboDataSrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            graph3D.AxisX_Legend = null;
            graph3D.AxisY_Legend = null;
            graph3D.AxisZ_Legend = null;

            switch (comboDataSrc.SelectedIndex)
            {
                case 0:
                    Draw("50"); break;
                case 1:
                    Draw("60"); break;
                case 2:
                    Draw("70"); break;
                case 3:
                    Draw("80"); break;
                case 4:
                    Draw("90"); break;
                case 5:
                    Draw("100"); break;
            }
        }

        private void comboColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color[] c_Colors = ColorSchema.GetSchema((eSchema)comboColors.SelectedIndex);
            graph3D.SetColorScheme(c_Colors, 3);
        }

        private void comboRaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            graph3D.Raster = (eRaster)comboRaster.SelectedIndex;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            graph3D.SetCoefficients(2000, 70, 230);
        }

        private void btnScreenshot_Click(object sender, EventArgs e)
        {
            SaveFileDialog i_Dlg = new SaveFileDialog
            {
                Title = "Save as PNG image",
                Filter = "PNG Image|*.png",
                DefaultExt = ".png"
            };

            if (DialogResult.Cancel == i_Dlg.ShowDialog(this))
                return;

            Bitmap i_Bitmap = graph3D.GetScreenshot();
            try
            {
                i_Bitmap.Save(i_Dlg.FileName, ImageFormat.Png);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DefSurfaceZernike()
        {
            front.NumberCoefficients = NumberCoefficients;
            front.DiscretizationPupil = DiscretizationPupil;
            front.CoefficientsPolynomials = CoefficientsPolynomials;
            front.Polinoms.FormationZernike(front.NumberCoefficients, front.DiscretizationPupil);
            front.CalcWaveFront();

            i_Points3D = new cPoint3D[front.WaveFrontMatrix.GetLength(0), front.WaveFrontMatrix.GetLength(1)];

            for (int X = 0; X < front.WaveFrontMatrix.GetLength(0); X++)
            {
                for (int Y = 0; Y < front.WaveFrontMatrix.GetLength(1); Y++)
                {
                    i_Points3D[X, Y] = new cPoint3D(X, Y, front.WaveFrontMatrix[X, Y]);
                }
            }

            // Setting one of the strings = null results in hiding this legend
            //graph3D.AxisX_Legend = "pixels";
            //graph3D.AxisY_Legend = "pixels";
            //graph3D.AxisZ_Legend = "λ";

            // IMPORTANT: Normalize X,Y,Z separately because there is an extreme mismatch 
            // between X values (< 300) and Z values (> 30000)
            //Draw("50");
        }


        public WaveFront front = new WaveFront();

        public cPoint3D[,] i_Points3D;

        private void Draw(string resize)
        {
            var myresult = new MyResult();
            switch (resize)
            {
                case "<50":
                    myresult = ResizeDouble(0); break;
                case "50":
                    myresult = ResizeDouble(51); break;
                case "60":
                    myresult = ResizeDouble(61); break;
                case "70":
                    myresult = ResizeDouble(71); break;
                case "80":
                    myresult = ResizeDouble(81); break;
                case "90":
                    myresult = ResizeDouble(91); break;
                case "100":
                    myresult = ResizeDouble(101); break;
            }

            graph3D.AxisX_Legend = "pixels";
            graph3D.AxisY_Legend = "pixels";
            graph3D.AxisZ_Legend = "λ";
            graph3D.AreaDisplay = myresult.RadiusVector;
            graph3D.SetSurfacePoints(myresult.i_Points3DCalc, eNormalize.Separate);
        }

        //****************************************************
        // Времянка переделать на масштабирование
        private MyResult ResizeDouble(int resize)
        {
            if (resize < 51) //(resize < 51)
            {
                return new MyResult
                {
                    i_Points3DCalc = i_Points3D,
                    RadiusVector = front.Polinoms.RadiusVector
                };
            }

            var result = new MyResult
            {
                i_Points3DCalc = new cPoint3D[resize, resize],
                RadiusVector = new double[resize, resize]
            };

            int icount = 0;
            int jcount = 0;

            for (int i = 0; i < resize; i++)
            {
                for (int j = 0; j < resize; j++)
                {
                    icount = i_Points3D.GetLength(0) / 2 - resize / 2 + i;
                    jcount = i_Points3D.GetLength(0) / 2 - resize / 2 + j;
                    result.i_Points3DCalc[i, j] = new cPoint3D
                    {
                        md_X = i,
                        md_Y = j,
                        md_Z = i_Points3D[icount, jcount].md_Z,
                    };
                    result.RadiusVector[i, j] = front.Polinoms.RadiusVector[icount, jcount];
                }
            }

            return result;
        }
        //****************************************************

        public void RefreshComboItems(int sizeR)
        {
            string[] ComboItems;
            if (sizeR < 51)
            {
                comboDataSrc.Items.Clear();
                comboDataSrc.Items.AddRange(new string[] {"<50"});
                //comboDataSrc.SelectedIndex = 0;
                comboDataSrc.Enabled = false;
            }
            else if (sizeR < 61)
            {
                comboDataSrc.Items.Clear();
                comboDataSrc.Items.AddRange(new string[] { "50" });
                //comboDataSrc.SelectedIndex = 0;
                comboDataSrc.Enabled = false;
            }
            else if (sizeR < 91)
            {
                comboDataSrc.Items.Clear();
                ComboItems = new string[sizeR/10-4];
                Array.Copy(ComboItemsAll, ComboItems, sizeR / 10 - 4);
                comboDataSrc.Items.AddRange(ComboItems);
                //comboDataSrc.SelectedIndex = 0;
                comboDataSrc.Enabled = true;
            }
            else
            {
                comboDataSrc.Items.Clear();
                comboDataSrc.Items.AddRange(ComboItemsAll);
                //comboDataSrc.SelectedIndex = 0;
                comboDataSrc.Enabled = true;
            }
        }

        public string[] ComboItemsAll = new string[] { "50", "60", "70", "80", "90", "100"};
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                var result = (MyResult)e.Result;
                front.Polinoms.RadiusVector = result.RadiusVector;
                i_Points3D = result.i_Points3DCalc;
                if (front.Polinoms.RadiusVector.GetLength(0) < 51)
                    Draw("<50");
                else Draw("50");
                RefreshComboItems(front.Polinoms.RadiusVector.GetLength(0));
                progressBar1.Value = 100;
                btnStop.Visible = false;
                ActivationForm(true);
            }
        }

        private void SetSurfaceZernike(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            var frontCalc = new WaveFront();
            frontCalc.NumberCoefficients = NumberCoefficients;
            frontCalc.DiscretizationPupil = DiscretizationPupil;
            frontCalc.CoefficientsPolynomials = CoefficientsPolynomials;
            frontCalc.Polinoms.FormationZernike(frontCalc.NumberCoefficients, frontCalc.DiscretizationPupil, worker, e);
            if (worker.CancellationPending == true)
            {
                return;
            }
            frontCalc.CalcWaveFront();
            //front.NumberCoefficients = NumberCoefficients;
            //front.DiscretizationPupil = DiscretizationPupil;
            //front.CoefficientsPolynomials = CoefficientsPolynomials;
            //front.Polinoms.FormationZernike(front.NumberCoefficients, front.DiscretizationPupil);
            //front.CalcWaveFront();

            var i_Points3DCalc = new cPoint3D[frontCalc.WaveFrontMatrix.GetLength(0), frontCalc.WaveFrontMatrix.GetLength(1)];

            //i_Points3D = new cPoint3D[front.WaveFrontMatrix.GetLength(0), front.WaveFrontMatrix.GetLength(1)];

            for (int X = 0; X < frontCalc.WaveFrontMatrix.GetLength(0); X++)
            {
                for (int Y = 0; Y < frontCalc.WaveFrontMatrix.GetLength(1); Y++)
                {
                    i_Points3DCalc[X, Y] = new cPoint3D(X, Y, frontCalc.WaveFrontMatrix[X, Y]);
                }
            }

            // Setting one of the strings = null results in hiding this legend
            //graph3D.AxisX_Legend = "pixels";
            //graph3D.AxisY_Legend = "pixels";
            //graph3D.AxisZ_Legend = "λ";

            e.Result = new MyResult
            {
                i_Points3DCalc = i_Points3DCalc,
                RadiusVector = frontCalc.Polinoms.RadiusVector
            };

                // IMPORTANT: Normalize X,Y,Z separately because there is an extreme mismatch 
                // between X values (< 300) and Z values (> 30000)
                //graph3D.AreaDisplay = front.Polinoms.RadiusVector;
                //graph3D.SetSurfacePoints(i_Points3D, eNormalize.Separate);
            }

        class MyResult
        {
            public cPoint3D[,] i_Points3DCalc;
            public double[,] RadiusVector;
        }

        private void SetNumCoeff(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }

        }

        private void SetDiscret(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }

        }

        private void changeNumCoeff(object sender, EventArgs e)
        {
            var regex = new Regex("^[1-9][0-9]*$");

            if (string.IsNullOrWhiteSpace(textBoxNumCoeff.Text) || !regex.IsMatch(textBoxNumCoeff.Text) ||
                int.Parse(textBoxNumCoeff.Text) > 500)
            {
                textBoxNumCoeff.BackColor = Color.LightCoral;
                SetbtnResult(allTextBoxesIsNotEmpty());
            }
            else
            {
                textBoxNumCoeff.BackColor = Color.White;
                //if (!initialZernikeCoeffForm) SetbtnResult(allTextBoxesIsNotEmpty());
                NumberCoefficients = int.Parse(textBoxNumCoeff.Text);
            }
        }

        private void changeDiscret(object sender, EventArgs e)
        {
            var regex = new Regex("^[1-9][0-9]*$");

            if (string.IsNullOrWhiteSpace(textBoxDiscret.Text) ||
                !regex.IsMatch(textBoxDiscret.Text) || int.Parse(textBoxDiscret.Text) < 4 ||
                int.Parse(textBoxDiscret.Text) > 500)
            {
                textBoxDiscret.BackColor = Color.LightCoral;
                SetbtnResult(allTextBoxesIsNotEmpty());
            }
            else
            {
                textBoxDiscret.BackColor = Color.White;
                //if (!initialZernikeCoeffForm) SetbtnResult(allTextBoxesIsNotEmpty());
                DiscretizationPupil = int.Parse(textBoxDiscret.Text) + 1;
            }
        }

        public void SetbtnResult(bool enable)
        {
            btnResult.Enabled = enable;
        }

        public bool allTextBoxesIsNotEmpty()
        {
            bool AllIsOk = true;
            foreach (Control C in this.Controls)
            {
                if (C.GetType() == typeof(TextBox))
                    AllIsOk &= (((TextBox)C).BackColor == Color.White)
                            && (((TextBox)C).TextLength > 0);
            }
            return AllIsOk;
        }

        public void ActivationForm(bool active)
        {
            if (initialZernikeCoeffForm) zernikeCoefficientsForm.Enabled = active;
            textBoxNumCoeff.Enabled = active;
            textBoxDiscret.Enabled = active;
            btnCoefficients.Enabled = active;
            comboDataSrc.Enabled = active;
        }

        private void clickResult(object sender, EventArgs e)
        {
            SetCoeff();
            btnStop.Visible = true;
            SetbtnResult(false);
            ActivationForm(false);
            worker.RunWorkerAsync();
            //SetbtnResult(false);
        }

        private ZernikeCoefficientsForm zernikeCoefficientsForm;

        private bool initialZernikeCoeffForm = false;

        private void btnCoeff_click(object sender, EventArgs e)
        {
            if (!initialZernikeCoeffForm)
            {
                SetbtnResult(false);
                zernikeCoefficientsForm = new ZernikeCoefficientsForm(NumberCoefficients)
                {
                    Visible = true
                };
                zernikeCoefficientsForm.SetbtnResult += SetbtnResult;
                initialZernikeCoeffForm = true;
            }
            else
            {
                zernikeCoefficientsForm.RefreshTextBoxes(NumberCoefficients);
                zernikeCoefficientsForm.Visible = true;
            }

        }

        public void SetCoeff()
        {
            if (initialZernikeCoeffForm)
            {
                CoefficientsPolynomials = new double[NumberCoefficients];

                for (int i = 0; i < zernikeCoefficientsForm.textBoxes.Length; i++)
                {
                    CoefficientsPolynomials[i] = double.Parse(zernikeCoefficientsForm.textBoxes[i].Text, System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                }
            }
            else SetDefaultCoeff();

        }

        public void SetDefaultCoeff()
        {
            CoefficientsPolynomials = new double[NumberCoefficients];

            Random rnd = new Random();
            for (int i = 0; i < NumberCoefficients; i++)
            {
                CoefficientsPolynomials[i] = (double)rnd.Next(-10, 11) / 10;
            }
        }

        private void RefreshCoeffBoard(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                if (initialZernikeCoeffForm) zernikeCoefficientsForm.RefreshTextBoxes(NumberCoefficients);
                SetbtnResult(allTextBoxesIsNotEmpty());
            }
        }

        private void btnEnableResultBoard(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                if (initialZernikeCoeffForm) zernikeCoefficientsForm.RefreshTextBoxes(NumberCoefficients);
                SetbtnResult(allTextBoxesIsNotEmpty());
            }
        }

        private void btnStopClick(object sender, EventArgs e)
        {
            btnStop.Visible = false;
            this.worker.CancelAsync();
            ActivationForm(true);
        }

        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}

