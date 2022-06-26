namespace Plot3D
{
    partial class Graph3DMainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInfo = new System.Windows.Forms.Label();
            this.comboColors = new System.Windows.Forms.ComboBox();
            this.comboDataSrc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboRaster = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.graph3D = new Plot3D.Graph3D();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(11, 164);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(28, 16);
            this.lblInfo.TabIndex = 9;
            this.lblInfo.Text = "Info";
            // 
            // comboColors
            // 
            this.comboColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboColors.FormattingEnabled = true;
            this.comboColors.Location = new System.Drawing.Point(12, 81);
            this.comboColors.Margin = new System.Windows.Forms.Padding(4);
            this.comboColors.MaxDropDownItems = 30;
            this.comboColors.Name = "comboColors";
            this.comboColors.Size = new System.Drawing.Size(160, 24);
            this.comboColors.TabIndex = 2;
            this.comboColors.SelectedIndexChanged += new System.EventHandler(this.comboColors_SelectedIndexChanged);
            // 
            // comboDataSrc
            // 
            this.comboDataSrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataSrc.FormattingEnabled = true;
            this.comboDataSrc.Items.AddRange(new object[] {
            "Surface"});
            this.comboDataSrc.Location = new System.Drawing.Point(12, 32);
            this.comboDataSrc.Margin = new System.Windows.Forms.Padding(4);
            this.comboDataSrc.MaxDropDownItems = 30;
            this.comboDataSrc.Name = "comboDataSrc";
            this.comboDataSrc.Size = new System.Drawing.Size(160, 24);
            this.comboDataSrc.TabIndex = 1;
            this.comboDataSrc.SelectedIndexChanged += new System.EventHandler(this.comboDataSrc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(183, 813);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(678, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Left mouse button : Elevate,  Right mouse: Rotate,  Left mouse + SHIFT: Move,  Le" +
    "ft mouse + CTRL or wheel: Zoom";
            // 
            // comboRaster
            // 
            this.comboRaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRaster.FormattingEnabled = true;
            this.comboRaster.Location = new System.Drawing.Point(12, 129);
            this.comboRaster.Margin = new System.Windows.Forms.Padding(4);
            this.comboRaster.MaxDropDownItems = 30;
            this.comboRaster.Name = "comboRaster";
            this.comboRaster.Size = new System.Drawing.Size(160, 24);
            this.comboRaster.TabIndex = 3;
            this.comboRaster.SelectedIndexChanged += new System.EventHandler(this.comboRaster_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Data Source:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Color Scheme:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Coordinate System:";
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.Location = new System.Drawing.Point(12, 222);
            this.btnScreenshot.Margin = new System.Windows.Forms.Padding(4);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(161, 28);
            this.btnScreenshot.TabIndex = 5;
            this.btnScreenshot.Text = "Save Screenshot";
            this.btnScreenshot.UseVisualStyleBackColor = true;
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 186);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(161, 28);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset Position";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            this.graph3D.Location = new System.Drawing.Point(185, 14);
            this.graph3D.Margin = new System.Windows.Forms.Padding(4);
            this.graph3D.Name = "graph3D";
            this.graph3D.PolygonLineColor = System.Drawing.Color.Black;
            this.graph3D.Raster = Plot3D.Graph3D.eRaster.Off;
            this.graph3D.Size = new System.Drawing.Size(875, 795);
            this.graph3D.TabIndex = 6;
            // 
            // Graph3DMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 836);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnScreenshot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboRaster);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboDataSrc);
            this.Controls.Add(this.comboColors);
            this.Controls.Add(this.graph3D);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(527, 481);
            this.Name = "Graph3DMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Plot3D.Graph3D graph3D;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ComboBox comboColors;
        private System.Windows.Forms.ComboBox comboDataSrc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboRaster;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.Button btnReset;

    }
}

