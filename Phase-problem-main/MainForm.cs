
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
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            NumberCoefficients = 10;
            DiscretizationPupil = 51;
            SetDefaultCoeff();
            DefSurfaceZernike();

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

        public WaveFront front = new WaveFront();

        public cPoint3D[,] i_Points3D;

        private void Draw(string resize)
        {
            var myresult = new MyResult();
            switch (resize)
            {
                case "<=50":
                    {
                        myresult.i_Points3DCalc = i_Points3D;
                        myresult.RadiusVector = front.Polinoms.RadiusVector;
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

            if (resize == i_Points3D.GetLength(0))
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
                    corr_x = (i + 0.5) / th * i_Points3D.GetLength(0) - 0.5;
                    corr_y = (j + 0.5) / tw * i_Points3D.GetLength(1) - 0.5;

                    point1[0] =  (int)Math.Floor(corr_x);
                    point1[1] = (int)Math.Floor(corr_y);

                    point2[0] = point1[0];
                    point2[1] = point1[1] + 1;

                    point3[0] = point1[0] + 1;
                    point3[1] = point1[1];

                    point4[0] = point1[0] + 1;
                    point4[1] = point1[1] + 1;

                    fr1 = (point2[1] - corr_y) * i_Points3D[point1[0], point1[1]].md_Z + (corr_y - point1[1]) * i_Points3D[point2[0], point2[1]].md_Z;
                    fr2 = (point2[1] - corr_y) * i_Points3D[point3[0], point3[1]].md_Z + (corr_y - point1[1]) * i_Points3D[point4[0], point4[1]].md_Z;

                    result.i_Points3DCalc[i, j] = new cPoint3D
                    {
                        md_X = i,
                        md_Y = j,
                        md_Z = (point3[0] - corr_x) * fr1 + (corr_x - point1[0]) * fr2,
                    };

                    fr1 = (point2[1] - corr_y) * front.Polinoms.RadiusVector[point1[0], point1[1]] + (corr_y - point1[1]) * front.Polinoms.RadiusVector[point2[0], point2[1]];
                    fr2 = (point2[1] - corr_y) * front.Polinoms.RadiusVector[point3[0], point3[1]] + (corr_y - point1[1]) * front.Polinoms.RadiusVector[point4[0], point4[1]];

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

        public string[] ComboItemsAll = new string[] { "50", "60", "70", "80", "90", "100"};
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                var result = (MyResult)e.Result;
                front.Polinoms.RadiusVector = result.RadiusVector;
                i_Points3D = result.i_Points3DCalc;
                if (front.Polinoms.RadiusVector.GetLength(0) <= 51)
                    Draw("<=50");
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
                NumberCoefficients = int.Parse(textBoxNumCoeff.Text);
                if (initialZernikeCoeffForm) zernikeCoefficientsForm.RefreshTextBoxes(NumberCoefficients);
                SetbtnResult(allTextBoxesIsNotEmpty());
            }
        }

        private void changeDiscret(object sender, EventArgs e)
        {
            var regex = new Regex("^[1-9][0-9]*$");

            if (string.IsNullOrWhiteSpace(textBoxDiscret.Text) ||
                !regex.IsMatch(textBoxDiscret.Text) || int.Parse(textBoxDiscret.Text) < 6 ||
                int.Parse(textBoxDiscret.Text) > 500)
            {
                textBoxDiscret.BackColor = Color.LightCoral;
                SetbtnResult(allTextBoxesIsNotEmpty());
            }
            else
            {
                textBoxDiscret.BackColor = Color.White;
                DiscretizationPupil = int.Parse(textBoxDiscret.Text) + 1;
                SetbtnResult(allTextBoxesIsNotEmpty());
            }
        }

        public void SetbtnResult(bool enable)
        {
            if (initialZernikeCoeffForm)
            {
                btnResult.Enabled = zernikeCoefficientsForm.Activeresult && enable;
            }
            else
            {
                btnResult.Enabled = enable;
            }
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
        }

        private void clickResult(object sender, EventArgs e)
        {
            SetCoeff();
            btnStop.Visible = true;
            SetbtnResult(false);
            ActivationForm(false);
            worker.RunWorkerAsync();
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

        private void DefSurfaceZernike()
        {
            int[,] devVlad = new int[,]
            {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,15,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,53,0,164,93,56,142,39,45,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,65,198,166,244,243,198,206,110,191,71,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,141,65,243,233,245,243,239,236,231,214,217,145,28,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,141,254,243,248,245,243,239,236,232,227,223,219,214,161,62,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,141,254,251,249,245,243,239,235,232,228,223,218,214,209,205,145,45,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,141,254,252,248,246,243,239,235,231,228,223,219,214,210,204,200,186,51,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,141,254,251,249,245,243,239,235,231,227,223,219,215,210,204,199,195,189,89,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,141,254,252,248,246,242,239,235,231,227,223,178,212,210,205,199,194,189,184,176,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,141,254,251,249,245,243,239,235,183,227,85,149,89,184,205,200,194,189,184,179,173,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,141,254,251,248,245,243,239,236,183,20,87,0,0,23,93,176,194,189,184,178,173,167,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,141,254,252,248,245,243,239,235,184,20,0,0,0,0,0,0,68,151,184,178,172,167,161,0,0,30,0,15,31,6,0,0,2,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,141,254,251,249,245,243,239,235,183,20,0,0,0,0,0,0,0,20,120,178,172,167,161,156,68,31,129,82,58,94,86,48,17,10,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,141,254,252,249,246,243,239,235,183,20,0,0,0,0,0,0,0,0,0,116,172,167,162,156,150,128,129,133,126,122,109,109,100,86,59,19,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,141,254,252,249,246,242,239,235,231,20,0,0,0,0,0,0,0,0,0,0,154,167,162,156,150,144,138,133,127,121,115,110,104,97,93,87,57,16,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,254,251,249,245,243,238,235,231,227,125,35,1,0,0,0,0,0,0,0,29,167,161,156,150,144,139,133,127,121,116,109,104,98,92,87,81,69,41,8,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,252,248,246,243,239,235,231,227,223,203,107,10,0,0,0,0,0,0,0,90,162,156,150,144,139,133,127,121,116,110,104,98,92,87,81,75,70,65,44,14,0,0,0,0,0,0 },
                { 0,0,0,0,0,146,226,243,239,235,232,227,223,218,214,181,99,20,0,0,0,0,0,65,162,156,150,144,139,133,127,122,116,110,104,98,92,87,81,75,70,65,59,52,24,0,0,0,0,0,0 },
                { 0,0,0,0,0,58,177,239,235,231,228,223,218,214,210,204,200,109,25,0,0,0,65,161,156,150,144,139,133,127,120,115,88,86,98,83,87,81,75,70,65,60,55,51,23,1,0,0,0,0,0 },
                { 0,0,0,0,0,0,38,143,213,227,223,219,214,209,204,199,195,160,83,0,0,65,162,156,150,145,139,133,127,114,94,60,51,12,41,50,81,75,70,66,60,55,50,46,34,2,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,39,149,223,219,214,209,204,199,194,189,184,177,97,65,162,157,150,144,139,133,127,115,29,46,0,7,0,0,0,34,59,65,59,55,51,45,41,37,5,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,4,52,150,210,209,204,200,195,189,184,178,173,149,162,156,150,144,139,133,127,114,28,0,0,0,0,0,0,0,9,35,60,55,50,46,41,37,33,24,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,8,125,192,200,195,189,184,178,173,167,162,156,150,144,139,133,127,115,29,0,0,0,0,0,0,0,0,0,6,55,50,45,41,37,33,28,25,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,2,51,146,194,189,184,178,172,168,161,157,150,144,139,133,127,114,28,0,0,0,0,0,0,0,0,0,0,0,50,45,40,37,33,28,24,18,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,22,112,168,178,173,167,162,156,151,144,139,133,127,119,28,0,0,0,0,0,0,0,0,0,0,0,0,45,41,36,33,28,25,20,3,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,38,124,173,168,162,156,150,145,139,133,127,121,93,17,0,0,0,0,0,0,0,0,0,0,0,0,41,37,32,28,24,21,17,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,1,37,109,154,156,150,144,139,133,127,121,116,95,47,0,0,0,0,0,0,0,0,0,0,0,0,36,33,28,24,20,17,11,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,95,145,144,139,132,127,121,115,110,104,90,50,13,0,0,0,0,0,0,0,0,0,12,32,28,25,20,16,14,5,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,37,105,139,133,126,121,115,109,105,98,92,82,41,5,0,0,0,0,0,0,0,12,32,28,24,21,16,14,8,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,78,117,121,116,110,104,99,93,87,81,65,33,6,0,0,0,0,0,12,32,28,24,20,17,14,11,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,29,89,115,110,104,98,93,88,81,76,71,65,34,8,0,0,0,12,33,28,25,20,16,14,11,9,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,21,68,97,98,92,87,82,75,71,65,60,47,22,0,0,12,33,28,25,21,17,14,11,8,2,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,63,92,87,81,76,70,66,60,55,50,44,22,12,33,28,24,21,17,14,11,8,2,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,22,61,82,76,71,65,60,55,51,45,40,32,33,28,25,20,17,14,11,8,2,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,45,66,65,60,55,51,46,41,36,33,28,24,21,16,14,11,9,2,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,18,47,60,55,50,46,41,37,32,28,24,20,17,14,11,8,2,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,33,46,45,41,36,33,28,24,20,16,14,11,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,10,31,41,37,32,28,25,20,17,14,11,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,9,24,32,28,24,21,16,14,11,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,17,24,20,17,14,11,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,6,15,17,14,11,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,9,8,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            };

            double[,] visualArea = new double[51, 51];

            double xAxis;
            double yAxis;

            i_Points3D = new cPoint3D[devVlad.GetLength(0), devVlad.GetLength(1)];
            for (int X = 0; X < devVlad.GetLength(0); X++)
            {
                for (int Y = 0; Y < devVlad.GetLength(1); Y++)
                {
                    i_Points3D[X, Y] = new cPoint3D(X, Y, devVlad[X, Y]);
                    xAxis = -1.0 + 2.0 * X / (51 - 1);
                    yAxis = -1.0 + 2.0 * Y / (51 - 1);
                    visualArea[X, Y] = Math.Sqrt(xAxis * xAxis + yAxis * yAxis);
                }
            }

            graph3D.AxisX_Legend = "pixels";
            graph3D.AxisY_Legend = "pixels";
            graph3D.AxisZ_Legend = "λ";
            graph3D.AreaDisplay = visualArea;
            graph3D.SetSurfacePoints(i_Points3D, eNormalize.Separate);
        }
    }
}

