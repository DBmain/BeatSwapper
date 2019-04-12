namespace BeatSwapper
{
    partial class bitrate
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
            this.bit96 = new System.Windows.Forms.RadioButton();
            this.bit128 = new System.Windows.Forms.RadioButton();
            this.bit192 = new System.Windows.Forms.RadioButton();
            this.bit256 = new System.Windows.Forms.RadioButton();
            this.bit320 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bit96
            // 
            this.bit96.AutoSize = true;
            this.bit96.Location = new System.Drawing.Point(17, 8);
            this.bit96.Name = "bit96";
            this.bit96.Size = new System.Drawing.Size(37, 17);
            this.bit96.TabIndex = 1;
            this.bit96.Text = "96";
            this.bit96.UseVisualStyleBackColor = true;
            this.bit96.CheckedChanged += new System.EventHandler(this.Bit96_CheckedChanged);
            // 
            // bit128
            // 
            this.bit128.AutoSize = true;
            this.bit128.Location = new System.Drawing.Point(17, 31);
            this.bit128.Name = "bit128";
            this.bit128.Size = new System.Drawing.Size(43, 17);
            this.bit128.TabIndex = 1;
            this.bit128.Text = "128";
            this.bit128.UseVisualStyleBackColor = true;
            this.bit128.CheckedChanged += new System.EventHandler(this.Bit128_CheckedChanged);
            // 
            // bit192
            // 
            this.bit192.AutoSize = true;
            this.bit192.Location = new System.Drawing.Point(17, 54);
            this.bit192.Name = "bit192";
            this.bit192.Size = new System.Drawing.Size(43, 17);
            this.bit192.TabIndex = 1;
            this.bit192.Text = "192";
            this.bit192.UseVisualStyleBackColor = true;
            this.bit192.CheckedChanged += new System.EventHandler(this.Bit192_CheckedChanged);
            // 
            // bit256
            // 
            this.bit256.AutoSize = true;
            this.bit256.Checked = true;
            this.bit256.Location = new System.Drawing.Point(17, 77);
            this.bit256.Name = "bit256";
            this.bit256.Size = new System.Drawing.Size(43, 17);
            this.bit256.TabIndex = 1;
            this.bit256.TabStop = true;
            this.bit256.Text = "256";
            this.bit256.UseVisualStyleBackColor = true;
            this.bit256.CheckedChanged += new System.EventHandler(this.Bit256_CheckedChanged);
            // 
            // bit320
            // 
            this.bit320.AutoSize = true;
            this.bit320.Location = new System.Drawing.Point(17, 100);
            this.bit320.Name = "bit320";
            this.bit320.Size = new System.Drawing.Size(43, 17);
            this.bit320.TabIndex = 1;
            this.bit320.Text = "320";
            this.bit320.UseVisualStyleBackColor = true;
            this.bit320.CheckedChanged += new System.EventHandler(this.Bit320_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // bitrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(77, 159);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bit320);
            this.Controls.Add(this.bit256);
            this.Controls.Add(this.bit192);
            this.Controls.Add(this.bit128);
            this.Controls.Add(this.bit96);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "bitrate";
            this.Text = "Bitrate:";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Bitrate_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton bit96;
        private System.Windows.Forms.RadioButton bit128;
        private System.Windows.Forms.RadioButton bit192;
        private System.Windows.Forms.RadioButton bit256;
        private System.Windows.Forms.RadioButton bit320;
        private System.Windows.Forms.Button button1;
    }
}