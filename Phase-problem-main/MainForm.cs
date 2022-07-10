using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.ComponentModel;

using Plot3D;

using cPoint3D   = Plot3D.Graph3D.cPoint3D;
using eRaster    = Plot3D.Graph3D.eRaster;
using eNormalize = Plot3D.Graph3D.eNormalize;
using eSchema    = Plot3D.ColorSchema.eSchema;

namespace Phase_problem_main
{
    public partial class MainForm : Form
    {
        const int MAX_NUM_Coeff = 1000;
        const int MAX_Discret = 1000;
        public int NumberCoefficients { get; set; }
        public int DiscretizationPupil { get; set; }
        public double[] CoefficientsPolynomials { get; set; }

        private WaveFront front = new WaveFront();
        public WaveFront Front
        {
            get { return front; }
            set { front = value; }
        }
        public cPoint3D[,] IPoints3D { get; set; }

        private string[] comboItemsAll = new string[] { "50", "60", "70", "80", "90", "100" };
        public string[] ComboItemsAll
        {
            get { return comboItemsAll; }
            set { comboItemsAll = value; }
        }
        public class MyResult
        {
            public cPoint3D[,] i_Points3DCalc;
            public double[,] RadiusVector;
        }

        private ZernikeCoefficientsForm zernikeCoefficientsForm;

        private bool initialZernikeCoeffForm = false;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            NumberCoefficients = 10; // default
            DiscretizationPupil = 51; // default
            SetDefaultCoeff();

            // Вывод дефолтной поверхности
            var defaultResult = DefaultSurface.Surface();
            IPoints3D = defaultResult.i_Points3DCalc;
            Front.Polinoms.RadiusVector = defaultResult.RadiusVector;
            Draw("50");

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
        }

        private void ComboDataSrcSelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void ComboColorsSelectedIndexChanged(object sender, EventArgs e)
        {
            Color[] c_Colors = ColorSchema.GetSchema((eSchema)comboColors.SelectedIndex);
            graph3D.SetColorScheme(c_Colors, 3);
        }

        private void ComboRasterSelectedIndexChanged(object sender, EventArgs e)
        {
            graph3D.Raster = (eRaster)comboRaster.SelectedIndex;
        }

        private void BtnResetClick(object sender, EventArgs e)
        {
            graph3D.SetCoefficients(2000, 70, 230);
        }

        private void BtnScreenshotClick(object sender, EventArgs e)
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

        private void Draw(string resize)
        {
            var myresult = new MyResult();
            switch (resize)
            {
                case "<=50":
                    {
                        myresult.i_Points3DCalc = IPoints3D;
                        myresult.RadiusVector = Front.Polinoms.RadiusVector;
                        break;
                    }
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

        private MyResult ResizeDouble(int resize)
        {

            if (resize == IPoints3D.GetLength(0))
            {
                return new MyResult
                {
                    i_Points3DCalc = IPoints3D,
                    RadiusVector = Front.Polinoms.RadiusVector
                };
            }

            var result = new MyResult
            {
                i_Points3DCalc = new cPoint3D[resize, resize],
                RadiusVector = new double[resize, resize]
            };

            int th = resize;
            int tw = resize;

            double corr_x;
            double corr_y;

            var point1 = new int[2];
            var point2 = new int[2];
            var point3 = new int[2];
            var point4 = new int[2];

            double fr1;
            double fr2;

            for (int i = 0; i < th; i++)
            {
                for(int j = 0; j < tw; j++)
                {
                    corr_x = (i + 0.5) / th * IPoints3D.GetLength(0) - 0.5;
                    corr_y = (j + 0.5) / tw * IPoints3D.GetLength(1) - 0.5;

                    point1[0] =  (int)Math.Floor(corr_x);
                    point1[1] = (int)Math.Floor(corr_y);

                    point2[0] = point1[0];
                    point2[1] = point1[1] + 1;

                    point3[0] = point1[0] + 1;
                    point3[1] = point1[1];

                    point4[0] = point1[0] + 1;
                    point4[1] = point1[1] + 1;

                    fr1 = (point2[1] - corr_y) * IPoints3D[point1[0], point1[1]].md_Z + (corr_y - point1[1]) * IPoints3D[point2[0], point2[1]].md_Z;
                    fr2 = (point2[1] - corr_y) * IPoints3D[point3[0], point3[1]].md_Z + (corr_y - point1[1]) * IPoints3D[point4[0], point4[1]].md_Z;

                    result.i_Points3DCalc[i, j] = new cPoint3D
                    {
                        md_X = i,
                        md_Y = j,
                        md_Z = (point3[0] - corr_x) * fr1 + (corr_x - point1[0]) * fr2,
                    };

                    fr1 = (point2[1] - corr_y) * Front.Polinoms.RadiusVector[point1[0], point1[1]] + (corr_y - point1[1]) * Front.Polinoms.RadiusVector[point2[0], point2[1]];
                    fr2 = (point2[1] - corr_y) * Front.Polinoms.RadiusVector[point3[0], point3[1]] + (corr_y - point1[1]) * Front.Polinoms.RadiusVector[point4[0], point4[1]];

                    result.RadiusVector[i, j] = (point3[0] - corr_x) * fr1 + (corr_x - point1[0]) * fr2;
                }
            }
            return result;
        }

        public void RefreshComboItems(int sizeR)
        {
            string[] ComboItems;
            if (sizeR <= 51)
            {
                comboDataSrc.Items.Clear();
                comboDataSrc.Items.AddRange(new string[] {"<=50"});
                comboDataSrc.Enabled = false;
            }
            else if (sizeR < 61)
            {
                comboDataSrc.Items.Clear();
                comboDataSrc.Items.AddRange(new string[] { "50" });
                comboDataSrc.Enabled = false;
            }
            else if (sizeR < 91)
            {
                comboDataSrc.Items.Clear();
                ComboItems = new string[sizeR/10-4];
                Array.Copy(ComboItemsAll, ComboItems, sizeR / 10 - 4);
                comboDataSrc.Items.AddRange(ComboItems);
                comboDataSrc.Enabled = true;
            }
            else
            {
                comboDataSrc.Items.Clear();
                comboDataSrc.Items.AddRange(ComboItemsAll);
                comboDataSrc.Enabled = true;
            }
        }

        private void BgwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                var result = (MyResult)e.Result;
                Front.Polinoms.RadiusVector = result.RadiusVector;
                IPoints3D = result.i_Points3DCalc;

                if (Front.Polinoms.RadiusVector.GetLength(0) <= 51)
                    Draw("<=50");
                else Draw("50");

                RefreshComboItems(Front.Polinoms.RadiusVector.GetLength(0));
                progressBar1.Value = 100;
                btnStop.Visible = false;
                ActivationForm(true);
            }
        }

        private void SetSurfaceZernike(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            var frontCalc = new WaveFront
            {
                NumberCoefficients = NumberCoefficients,
                DiscretizationPupil = DiscretizationPupil,
                CoefficientsOfPolynomials = CoefficientsPolynomials
            };
            frontCalc.Polinoms.FormationZernike(frontCalc.NumberCoefficients, frontCalc.DiscretizationPupil, worker, e);
            
            if (worker.CancellationPending == true)
            {
                return;
            }

            frontCalc.CalcWaveFront();

            var i_Points3DCalc = new cPoint3D[frontCalc.WaveFrontMatrix.GetLength(0), frontCalc.WaveFrontMatrix.GetLength(1)];

            for (int X = 0; X < frontCalc.WaveFrontMatrix.GetLength(0); X++)
            {
                for (int Y = 0; Y < frontCalc.WaveFrontMatrix.GetLength(1); Y++)
                {
                    i_Points3DCalc[X, Y] = new cPoint3D(X, Y, frontCalc.WaveFrontMatrix[X, Y]);
                }
            }

            e.Result = new MyResult
            {
                i_Points3DCalc = i_Points3DCalc,
                RadiusVector = frontCalc.Polinoms.RadiusVector
            };
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

        private void ChangeNumCoeff(object sender, EventArgs e)
        {
            var regex = new Regex("^[1-9][0-9]*$");

            if (string.IsNullOrWhiteSpace(textBoxNumCoeff.Text) ||
                !regex.IsMatch(textBoxNumCoeff.Text) ||
                int.Parse(textBoxNumCoeff.Text) > MAX_NUM_Coeff)
            {
                textBoxNumCoeff.BackColor = Color.LightCoral;
                SetbtnResult(AllTextBoxesIsNotEmpty());
            }
            else
            {
                textBoxNumCoeff.BackColor = Color.White;
                NumberCoefficients = int.Parse(textBoxNumCoeff.Text);
                if (initialZernikeCoeffForm) zernikeCoefficientsForm.RefreshTextBoxes(NumberCoefficients);
                SetbtnResult(AllTextBoxesIsNotEmpty());
            }
        }

        private void ChangeDiscret(object sender, EventArgs e)
        {
            var regex = new Regex("^[1-9][0-9]*$");

            if (string.IsNullOrWhiteSpace(textBoxDiscret.Text) ||
                !regex.IsMatch(textBoxDiscret.Text) ||
                int.Parse(textBoxDiscret.Text) < 6 ||
                int.Parse(textBoxDiscret.Text) > MAX_Discret)
            {
                textBoxDiscret.BackColor = Color.LightCoral;
                SetbtnResult(AllTextBoxesIsNotEmpty());
            }
            else
            {
                textBoxDiscret.BackColor = Color.White;
                DiscretizationPupil = int.Parse(textBoxDiscret.Text) + 1;
                SetbtnResult(AllTextBoxesIsNotEmpty());
            }
        }

        public void SetbtnResult(bool enable)
        {
            if (initialZernikeCoeffForm)
            {
                btnResult.Enabled = zernikeCoefficientsForm.ActiveResult && enable;
            }
            else
            {
                btnResult.Enabled = enable;
            }
        }

        public bool AllTextBoxesIsNotEmpty()
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
        }

        private void ClickResult(object sender, EventArgs e)
        {
            SetCoeff();
            btnStop.Visible = true;
            SetbtnResult(false);
            ActivationForm(false);
            worker.RunWorkerAsync();
        }

        private void BtnCoeffClick(object sender, EventArgs e)
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
                SetbtnResult(AllTextBoxesIsNotEmpty());
            }
        }

        private void BtnEnableResultBoard(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                if (initialZernikeCoeffForm) zernikeCoefficientsForm.RefreshTextBoxes(NumberCoefficients);
                SetbtnResult(AllTextBoxesIsNotEmpty());
            }
        }

        private void BtnStopClick(object sender, EventArgs e)
        {
            btnStop.Visible = false;
            this.worker.CancelAsync();
            ActivationForm(true);
        }

        private void BgwProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}

