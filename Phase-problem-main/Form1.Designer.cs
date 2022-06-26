
namespace Phase_problem_main
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button_Start = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.graph3D = new Plot3D.Graph3D();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboRaster = new System.Windows.Forms.ComboBox();
            this.comboDataSrc = new System.Windows.Forms.ComboBox();
            this.comboColors = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(199, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(679, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(30, 97);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(144, 31);
            this.button_Start.TabIndex = 1;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(74, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(74, 69);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "KC0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "M";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "C0";
            // 
            // graph3D
            // 
            this.graph3D.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graph3D.AxisX_Color = System.Drawing.Color.DarkBlue;
            this.graph3D.AxisX_Legend = null;
            this.graph3D.AxisY_Color = System.Drawing.Color.DarkGreen;
            this.graph3D.AxisY_Legend = null;
            this.graph3D.AxisZ_Color = System.Drawing.Color.DarkRed;
            this.graph3D.AxisZ_Legend = null;
            this.graph3D.BackColor = System.Drawing.Color.White;
            this.graph3D.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.graph3D.Cursor = System.Windows.Forms.Cursors.Default;
            this.graph3D.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graph3D.Location = new System.Drawing.Point(199, 54);
            this.graph3D.Margin = new System.Windows.Forms.Padding(4);
            this.graph3D.Name = "graph3D";
            this.graph3D.PolygonLineColor = System.Drawing.Color.Black;
            this.graph3D.Raster = Plot3D.Graph3D.eRaster.Off;
            this.graph3D.Size = new System.Drawing.Size(882, 556);
            this.graph3D.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(303, 614);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(678, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Left mouse button : Elevate,  Right mouse: Rotate,  Left mouse + SHIFT: Move,  Le" +
    "ft mouse + CTRL or wheel: Zoom";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(14, 315);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(161, 28);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "Reset Position";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.Location = new System.Drawing.Point(14, 351);
            this.btnScreenshot.Margin = new System.Windows.Forms.Padding(4);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(161, 28);
            this.btnScreenshot.TabIndex = 22;
            this.btnScreenshot.Text = "Save Screenshot";
            this.btnScreenshot.UseVisualStyleBackColor = true;
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 240);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Coordinate System:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 191);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Color Scheme:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 143);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "Data Source:";
            // 
            // comboRaster
            // 
            this.comboRaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRaster.FormattingEnabled = true;
            this.comboRaster.Location = new System.Drawing.Point(14, 258);
            this.comboRaster.Margin = new System.Windows.Forms.Padding(4);
            this.comboRaster.MaxDropDownItems = 30;
            this.comboRaster.Name = "comboRaster";
            this.comboRaster.Size = new System.Drawing.Size(160, 24);
            this.comboRaster.TabIndex = 20;
            this.comboRaster.SelectedIndexChanged += new System.EventHandler(this.comboRaster_SelectedIndexChanged);
            // 
            // comboDataSrc
            // 
            this.comboDataSrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataSrc.FormattingEnabled = true;
            this.comboDataSrc.Items.AddRange(new object[] {
            "Zernike",
            "Surface"});
            this.comboDataSrc.Location = new System.Drawing.Point(14, 161);
            this.comboDataSrc.Margin = new System.Windows.Forms.Padding(4);
            this.comboDataSrc.MaxDropDownItems = 30;
            this.comboDataSrc.Name = "comboDataSrc";
            this.comboDataSrc.Size = new System.Drawing.Size(160, 24);
            this.comboDataSrc.TabIndex = 18;
            this.comboDataSrc.SelectedIndexChanged += new System.EventHandler(this.comboDataSrc_SelectedIndexChanged);
            // 
            // comboColors
            // 
            this.comboColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboColors.FormattingEnabled = true;
            this.comboColors.Location = new System.Drawing.Point(14, 210);
            this.comboColors.Margin = new System.Windows.Forms.Padding(4);
            this.comboColors.MaxDropDownItems = 30;
            this.comboColors.Name = "comboColors";
            this.comboColors.Size = new System.Drawing.Size(160, 24);
            this.comboColors.TabIndex = 19;
            this.comboColors.SelectedIndexChanged += new System.EventHandler(this.comboColors_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 639);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnScreenshot);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboRaster);
            this.Controls.Add(this.comboDataSrc);
            this.Controls.Add(this.comboColors);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.graph3D);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.progressBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Plot3D.Graph3D graph3D;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboRaster;
        private System.Windows.Forms.ComboBox comboDataSrc;
        private System.Windows.Forms.ComboBox comboColors;
    }
}