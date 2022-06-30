
using System.ComponentModel;
using System.Drawing;

namespace Phase_problem_main
{
    partial class MainForm
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
            this.btnResult = new System.Windows.Forms.Button();
            this.textBoxNumCoeff = new System.Windows.Forms.TextBox();
            this.textBoxDiscret = new System.Windows.Forms.TextBox();
            this.labelNumCoeff = new System.Windows.Forms.Label();
            this.labelDiscret = new System.Windows.Forms.Label();
            this.graph3D = new Plot3D.Graph3D();
            this.labelInfoMouse = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.labelCoordSystem = new System.Windows.Forms.Label();
            this.labelColorScheme = new System.Windows.Forms.Label();
            this.labelDataSource = new System.Windows.Forms.Label();
            this.comboRaster = new System.Windows.Forms.ComboBox();
            this.comboDataSrc = new System.Windows.Forms.ComboBox();
            this.comboColors = new System.Windows.Forms.ComboBox();
            this.btnCoefficients = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(199, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(882, 23);
            this.progressBar1.Step = 5;
            this.progressBar1.TabIndex = 0;
            // 
            // btnResult
            // 
            this.btnResult.Location = new System.Drawing.Point(20, 200);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(144, 52);
            this.btnResult.TabIndex = 1;
            this.btnResult.Text = "Result";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.clickResult);
            // 
            // textBoxNumCoeff
            // 
            this.textBoxNumCoeff.BackColor = System.Drawing.Color.White;
            this.textBoxNumCoeff.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxNumCoeff.Location = new System.Drawing.Point(20, 47);
            this.textBoxNumCoeff.Name = "textBoxNumCoeff";
            this.textBoxNumCoeff.Size = new System.Drawing.Size(144, 22);
            this.textBoxNumCoeff.TabIndex = 2;
            this.textBoxNumCoeff.Text = "10";
            this.textBoxNumCoeff.TextChanged += new System.EventHandler(this.changeNumCoeff);
            this.textBoxNumCoeff.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RefreshCoeffBoard);
            this.textBoxNumCoeff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetNumCoeff);
            // 
            // textBoxDiscret
            // 
            this.textBoxDiscret.BackColor = System.Drawing.Color.White;
            this.textBoxDiscret.Location = new System.Drawing.Point(20, 107);
            this.textBoxDiscret.Name = "textBoxDiscret";
            this.textBoxDiscret.Size = new System.Drawing.Size(144, 22);
            this.textBoxDiscret.TabIndex = 3;
            this.textBoxDiscret.Text = "50";
            this.textBoxDiscret.TextChanged += new System.EventHandler(this.changeDiscret);
            this.textBoxDiscret.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEnableResultBoard);
            this.textBoxDiscret.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetDiscret);
            // 
            // labelNumCoeff
            // 
            this.labelNumCoeff.AutoSize = true;
            this.labelNumCoeff.Location = new System.Drawing.Point(17, 12);
            this.labelNumCoeff.Name = "labelNumCoeff";
            this.labelNumCoeff.Size = new System.Drawing.Size(127, 32);
            this.labelNumCoeff.TabIndex = 5;
            this.labelNumCoeff.Text = "Number Coefficients\r\n(1 <--> 500)";
            // 
            // labelDiscret
            // 
            this.labelDiscret.AutoSize = true;
            this.labelDiscret.Location = new System.Drawing.Point(17, 72);
            this.labelDiscret.Name = "labelDiscret";
            this.labelDiscret.Size = new System.Drawing.Size(87, 32);
            this.labelDiscret.TabIndex = 6;
            this.labelDiscret.Text = "Discretization\r\n(4 <--> 500)";
            // 
            // graph3D
            // 
            this.graph3D.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graph3D.AreaDisplay = null;
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
            // labelInfoMouse
            // 
            this.labelInfoMouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelInfoMouse.AutoSize = true;
            this.labelInfoMouse.ForeColor = System.Drawing.Color.Blue;
            this.labelInfoMouse.Location = new System.Drawing.Point(196, 614);
            this.labelInfoMouse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInfoMouse.Name = "labelInfoMouse";
            this.labelInfoMouse.Size = new System.Drawing.Size(675, 16);
            this.labelInfoMouse.TabIndex = 14;
            this.labelInfoMouse.Text = "Left mouse : Rotate. Right mouse button : Elevate. SHIFT + Left mouse : Move. CTR" +
    "L + Left mouse or wheel: Zoom";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(16, 456);
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
            this.btnScreenshot.Location = new System.Drawing.Point(16, 492);
            this.btnScreenshot.Margin = new System.Windows.Forms.Padding(4);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(161, 28);
            this.btnScreenshot.TabIndex = 22;
            this.btnScreenshot.Text = "Save Screenshot";
            this.btnScreenshot.UseVisualStyleBackColor = true;
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // labelCoordSystem
            // 
            this.labelCoordSystem.AutoSize = true;
            this.labelCoordSystem.Location = new System.Drawing.Point(13, 381);
            this.labelCoordSystem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCoordSystem.Name = "labelCoordSystem";
            this.labelCoordSystem.Size = new System.Drawing.Size(124, 16);
            this.labelCoordSystem.TabIndex = 25;
            this.labelCoordSystem.Text = "Coordinate System:";
            // 
            // labelColorScheme
            // 
            this.labelColorScheme.AutoSize = true;
            this.labelColorScheme.Location = new System.Drawing.Point(13, 332);
            this.labelColorScheme.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelColorScheme.Name = "labelColorScheme";
            this.labelColorScheme.Size = new System.Drawing.Size(95, 16);
            this.labelColorScheme.TabIndex = 24;
            this.labelColorScheme.Text = "Color Scheme:";
            // 
            // labelDataSource
            // 
            this.labelDataSource.AutoSize = true;
            this.labelDataSource.Location = new System.Drawing.Point(13, 284);
            this.labelDataSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDataSource.Name = "labelDataSource";
            this.labelDataSource.Size = new System.Drawing.Size(138, 16);
            this.labelDataSource.TabIndex = 23;
            this.labelDataSource.Text = "Visualization of points:";
            // 
            // comboRaster
            // 
            this.comboRaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRaster.FormattingEnabled = true;
            this.comboRaster.Location = new System.Drawing.Point(16, 399);
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
            this.comboDataSrc.Enabled = false;
            this.comboDataSrc.FormattingEnabled = true;
            this.comboDataSrc.Items.AddRange(new object[] {
            "50"});
            this.comboDataSrc.Location = new System.Drawing.Point(16, 302);
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
            this.comboColors.Location = new System.Drawing.Point(16, 351);
            this.comboColors.Margin = new System.Windows.Forms.Padding(4);
            this.comboColors.MaxDropDownItems = 30;
            this.comboColors.Name = "comboColors";
            this.comboColors.Size = new System.Drawing.Size(160, 24);
            this.comboColors.TabIndex = 19;
            this.comboColors.SelectedIndexChanged += new System.EventHandler(this.comboColors_SelectedIndexChanged);
            // 
            // btnCoefficients
            // 
            this.btnCoefficients.Location = new System.Drawing.Point(20, 152);
            this.btnCoefficients.Name = "btnCoefficients";
            this.btnCoefficients.Size = new System.Drawing.Size(144, 28);
            this.btnCoefficients.TabIndex = 26;
            this.btnCoefficients.Text = "Set Coefficients";
            this.btnCoefficients.UseVisualStyleBackColor = true;
            this.btnCoefficients.Click += new System.EventHandler(this.btnCoeff_click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(20, 200);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(144, 52);
            this.btnStop.TabIndex = 27;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStopClick);
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SetSurfaceZernike);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_ProgressChanged);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 639);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.graph3D);
            this.Controls.Add(this.btnCoefficients);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnScreenshot);
            this.Controls.Add(this.labelCoordSystem);
            this.Controls.Add(this.labelColorScheme);
            this.Controls.Add(this.labelDataSource);
            this.Controls.Add(this.comboRaster);
            this.Controls.Add(this.comboDataSrc);
            this.Controls.Add(this.comboColors);
            this.Controls.Add(this.labelInfoMouse);
            this.Controls.Add(this.labelDiscret);
            this.Controls.Add(this.labelNumCoeff);
            this.Controls.Add(this.textBoxDiscret);
            this.Controls.Add(this.textBoxNumCoeff);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.progressBar1);
            this.Name = "MainForm";
            this.Text = "Wavefront and intensity distribution of a point source(in development)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.TextBox textBoxNumCoeff;
        private System.Windows.Forms.TextBox textBoxDiscret;
        private System.Windows.Forms.Label labelNumCoeff;
        private System.Windows.Forms.Label labelDiscret;
        private Plot3D.Graph3D graph3D;
        private System.Windows.Forms.Label labelInfoMouse;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.Label labelCoordSystem;
        private System.Windows.Forms.Label labelColorScheme;
        private System.Windows.Forms.Label labelDataSource;
        private System.Windows.Forms.ComboBox comboRaster;
        private System.Windows.Forms.ComboBox comboDataSrc;
        private System.Windows.Forms.ComboBox comboColors;
        private System.Windows.Forms.Button btnCoefficients;
        private System.Windows.Forms.Button btnStop;
        private BackgroundWorker worker;
    }
}