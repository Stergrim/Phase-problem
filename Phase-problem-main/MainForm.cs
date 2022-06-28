
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using cPoint3D            = Plot3D.Graph3D.cPoint3D;
using eRaster             = Plot3D.Graph3D.eRaster;
using eNormalize          = Plot3D.Graph3D.eNormalize;
using eSchema             = Plot3D.ColorSchema.eSchema;

namespace Phase_problem_main
{
    using Plot3D;

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

            comboDataSrc.SelectedIndex = 0; // set "SetSurfaceZernike"
        }

        private void comboDataSrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            graph3D.AxisX_Legend = null;
            graph3D.AxisY_Legend = null;
            graph3D.AxisZ_Legend = null;

            switch (comboDataSrc.SelectedIndex)
            {
                case 0: SetSurfaceZernike(); break;
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

        // ================================================================================================

        /// <summary>
        /// This demonstrates how to set X, Y, Z values directly (without function)
        /// </summary>

        public WaveFront front = new WaveFront();

        private void SetSurfaceZernike()
        {
            front.NumberCoefficients = NumberCoefficients;
            front.DiscretizationPupil = DiscretizationPupil;
            front.CoefficientsPolynomials = CoefficientsPolynomials;
            front.Polinoms.FormationZernike(front.NumberCoefficients, front.DiscretizationPupil);
            front.CalcWaveFront();

            cPoint3D[,] i_Points3D = new cPoint3D[front.WaveFrontMatrix.GetLength(0), front.WaveFrontMatrix.GetLength(1)];

            for (int X = 0; X < front.WaveFrontMatrix.GetLength(0); X++)
            {
                for (int Y = 0; Y < front.WaveFrontMatrix.GetLength(1); Y++)
                {
                    i_Points3D[X, Y] = new cPoint3D(X, Y, front.WaveFrontMatrix[X, Y]);
                }
            }

            // Setting one of the strings = null results in hiding this legend
            graph3D.AxisX_Legend = "pixels";
            graph3D.AxisY_Legend = "pixels";
            graph3D.AxisZ_Legend = "λ";

            // IMPORTANT: Normalize X,Y,Z separately because there is an extreme mismatch 
            // between X values (< 300) and Z values (> 30000)
            graph3D.AreaDisplay = front.Polinoms.RadiusVector;
            graph3D.SetSurfacePoints(i_Points3D, eNormalize.Separate);
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
                if (!initialZernikeCoeffForm) SetbtnResult(allTextBoxesIsNotEmpty());
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
                if (!initialZernikeCoeffForm) SetbtnResult(allTextBoxesIsNotEmpty());
                DiscretizationPupil = int.Parse(textBoxDiscret.Text);
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

        private void clickResult(object sender, EventArgs e)
        {
            SetCoeff();
            SetSurfaceZernike();
            SetbtnResult(false);
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
    }
}

