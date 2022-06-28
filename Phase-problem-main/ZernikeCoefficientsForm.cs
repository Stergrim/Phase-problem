using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phase_problem_main
{
    public partial class ZernikeCoefficientsForm : Form
    {
        public TextBox[] textBoxes;
        public Label[] labels;

        public ZernikeCoefficientsForm(int textBoxesCount)
        {
            InitializeComponent();
            textBoxes = new TextBox[textBoxesCount];
            labels = new Label[textBoxesCount];
            InitialTextBoxes(textBoxesCount, 0);
            RandomInitialTextBoxes();
        }
        private void InitialTextBoxes(int textBoxesCount, int oldLength)
        {
            int count = 0;
            int borderWidth = 10;
            int borderHeight = 10;
            int widthTextBox = 50;
            int heightTextBox = 20;
            int sizeWidth = 650;
            int sizeHeight = 400;
            this.Size = new Size(sizeWidth, sizeHeight);
            int numTextBoxInLine = (sizeWidth - 2 * borderWidth) / (widthTextBox + borderWidth);
            int countInLine = 0;
            for (int i = 0; true; i += heightTextBox + borderHeight)
            {
                for (int j = 0; true; j += widthTextBox + borderWidth)
                {
                    if (count >= oldLength)
                    {
                        labels[count] = new Label
                        {
                            Top = 2 * i + borderHeight,
                            Left = j + borderWidth,
                            Width = widthTextBox,
                            Height = heightTextBox,
                            Text = "C" + (count + 1).ToString(),
                            TextAlign = ContentAlignment.TopCenter
                        };
                        this.Controls.Add(labels[count]);
                        textBoxes[count] = new TextBox
                        {
                            Top = 2 * i + borderHeight + heightTextBox,
                            Left = j + borderWidth,
                            Width = widthTextBox,
                            Height = heightTextBox,
                            Text = "0",
                            TextAlign = HorizontalAlignment.Center
                        };
                        this.textBoxes[count].TextChanged += new EventHandler(this.changeCoeff);
                        this.textBoxes[count].KeyPress += new KeyPressEventHandler(this.SetCoeff);
                        this.Controls.Add(textBoxes[count]);
                    }
                    count++;
                    if (count > textBoxesCount - 1) break;
                    countInLine++;
                    if (countInLine > numTextBoxInLine - 1) break;
                }
                countInLine = 0;
                if (count > textBoxesCount - 1) break;
            }
        }

        public void RefreshTextBoxes(int textBoxesCount)
        {
            int oldLength = labels.Length;
            if (textBoxesCount > oldLength)
            {
                Array.Resize(ref labels, textBoxesCount);
                Array.Resize(ref textBoxes, textBoxesCount);
                InitialTextBoxes(textBoxesCount, oldLength);
            }
            else
                RemoveTextBoxes(textBoxesCount, oldLength);
        }

        private void RemoveTextBoxes(int textBoxesCount, int oldLength)
        {
            for (int i = textBoxesCount; i < oldLength; i++)
            {
                this.Controls.Remove(labels[i]);
                this.Controls.Remove(textBoxes[i]);
            }
            Array.Resize(ref labels, textBoxesCount);
            Array.Resize(ref textBoxes, textBoxesCount);
        }

        private void RandomInitialTextBoxes()
        {
            Random rnd = new Random();
            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Text = ((double)rnd.Next(-10, 11) / 10).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            }
        }

        private void SetCoeff(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }

        }

        private void changeCoeff(object sender, EventArgs e)
        {
            var regex = new Regex("^[1-9][0-9]*$");

            var textBoxCurrent = (TextBox)sender;

            if (!regex.IsMatch(textBoxCurrent.Text))
                textBoxCurrent.BackColor = Color.Red;
            else textBoxCurrent.BackColor = Color.White;
        }

        private void ZernikeCoefficientsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
