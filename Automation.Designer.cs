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
            this.TBResult.Size = new System.Drawing.Size(858, 448);
            this.TBResult.TabIndex = 0;
            this.TBResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBResult_KeyDown);
            // 
            // BtnRun
            // 
            this.BtnRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRun.Location = new System.Drawing.Point(15, 472);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(858, 35);
            this.BtnRun.TabIndex = 1;
            this.BtnRun.Text = "Run";
            this.BtnRun.UseVisualStyleBackColor = true;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // Automation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 519);
            this.Controls.Add(this.BtnRun);
            this.Controls.Add(this.TBResult);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Automation";
            this.Text = "Automation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBResult;
        private System.Windows.Forms.Button BtnRun;
    }
}

