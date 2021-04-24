namespace Automation
{
    partial class Automation
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
            this.TBResult = new System.Windows.Forms.TextBox();
            this.BtnRun = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NUDDelayRiver = new System.Windows.Forms.NumericUpDown();
            this.NUDDelayCopy = new System.Windows.Forms.NumericUpDown();
            this.NUDDelayMouse = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDDelayRiver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDDelayCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDDelayMouse)).BeginInit();
            this.SuspendLayout();
            // 
            // TBResult
            // 
            this.TBResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBResult.Location = new System.Drawing.Point(15, 15);
            this.TBResult.Margin = new System.Windows.Forms.Padding(6);
            this.TBResult.Multiline = true;
            this.TBResult.Name = "TBResult";
            this.TBResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBResult.Size = new System.Drawing.Size(1087, 375);
            this.TBResult.TabIndex = 0;
            this.TBResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBResult_KeyDown);
            // 
            // BtnRun
            // 
            this.BtnRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRun.Location = new System.Drawing.Point(15, 516);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(1087, 35);
            this.BtnRun.TabIndex = 1;
            this.BtnRun.Text = "Run";
            this.BtnRun.UseVisualStyleBackColor = true;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NUDDelayRiver);
            this.groupBox1.Controls.Add(this.NUDDelayMouse);
            this.groupBox1.Controls.Add(this.NUDDelayCopy);
            this.groupBox1.Location = new System.Drawing.Point(15, 399);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1087, 111);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(722, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Delay for Calculate River";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Delay for Copy";
            // 
            // NUDDelayRiver
            // 
            this.NUDDelayRiver.Location = new System.Drawing.Point(941, 46);
            this.NUDDelayRiver.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUDDelayRiver.Name = "NUDDelayRiver";
            this.NUDDelayRiver.Size = new System.Drawing.Size(120, 29);
            this.NUDDelayRiver.TabIndex = 0;
            this.NUDDelayRiver.Value = new decimal(new int[] {
            7000,
            0,
            0,
            0});
            // 
            // NUDDelayCopy
            // 
            this.NUDDelayCopy.Location = new System.Drawing.Point(179, 51);
            this.NUDDelayCopy.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUDDelayCopy.Name = "NUDDelayCopy";
            this.NUDDelayCopy.Size = new System.Drawing.Size(120, 29);
            this.NUDDelayCopy.TabIndex = 0;
            this.NUDDelayCopy.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // NUDDelayMouse
            // 
            this.NUDDelayMouse.Location = new System.Drawing.Point(516, 51);
            this.NUDDelayMouse.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUDDelayMouse.Name = "NUDDelayMouse";
            this.NUDDelayMouse.Size = new System.Drawing.Size(120, 29);
            this.NUDDelayMouse.TabIndex = 0;
            this.NUDDelayMouse.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Delay for Mouse";
            // 
            // Automation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 563);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnRun);
            this.Controls.Add(this.TBResult);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Automation";
            this.Text = "Automation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDDelayRiver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDDelayCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDDelayMouse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBResult;
        private System.Windows.Forms.Button BtnRun;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NUDDelayRiver;
        private System.Windows.Forms.NumericUpDown NUDDelayCopy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NUDDelayMouse;
    }
}

