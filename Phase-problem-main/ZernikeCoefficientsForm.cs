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
        public event SetbtnResultActive SetbtnResult;
        public delegate void SetbtnResultActive(bool enable);

        public ZernikeCoefficientsForm(int textBoxesCount)
        {
            InitializeComponent();
            textBoxes = new TextBox[textBoxesCount];
            labels = new Label[textBoxesCount];
            InitialTextBoxes(textBoxesCount, 0);
            ZeroInitialTextBoxes();
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
            for (int i = heightTextBox-5; true; i += heightTextBox + borderHeight)
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
                            Text = "0.0",
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
        private void ZeroInitialTextBoxes()
        {
            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Text = "0.0";
            }
        }

        private void SetCoeff(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != '.' && number != '-')
            {
                e.Handled = true;
            }
            SetbtnResult(true);

            foreach (var box in textBoxes)
            {
                if (box.BackColor == Color.LightCoral)
                {
                    box.Text = "0.0";
                    box.BackColor = Color.White;
                }
            }
        }

        private void changeCoeff(object sender, EventArgs e)
        {
            var regex = new Regex("[0-9]?[.[0-9]+]?");
            var regexOnePoint = new Regex("^(?=[^.]*\\.?[^.]*$)");
            var regexOneMinus = new Regex("^\\-?\\d*\\.?\\d*$");

            var textBoxCurrent = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBoxCurrent.Text) || textBoxCurrent.Text == "." || textBoxCurrent.Text == "-")
            {
                textBoxCurrent.Text = "0.0";
            }
            else if (textBoxCurrent.BackColor == Color.LightCoral)
            {
                textBoxCurrent.BackColor = Color.White;
                SetbtnResult(true);
            }
            else if (!regex.IsMatch(textBoxCurrent.Text) || !regexOnePoint.IsMatch(textBoxCurrent.Text)|| !regexOneMinus.IsMatch(textBoxCurrent.Text))
            {
                textBoxCurrent.BackColor = Color.LightCoral;
                SetbtnResult(false);

            }
            else textBoxCurrent.BackColor = Color.White;
        }

        private void ZernikeCoefficientsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void clickReset(object sender, EventArgs e)
        {
            ZeroInitialTextBoxes();
            SetbtnResult(true);
        }

        private void clickRandom(object sender, EventArgs e)
        {
            RandomInitialTextBoxes();
            SetbtnResult(true);
        }
    }
}
