namespace VeriGuvenligi_AES_RSA_Hash
{
    partial class UserScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserScreen));
            this.bReceiver = new System.Windows.Forms.Button();
            this.bSender = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bReceiver
            // 
            this.bReceiver.Location = new System.Drawing.Point(16, 15);
            this.bReceiver.Margin = new System.Windows.Forms.Padding(4);
            this.bReceiver.Name = "bReceiver";
            this.bReceiver.Size = new System.Drawing.Size(188, 28);
            this.bReceiver.TabIndex = 0;
            this.bReceiver.Text = "Gelen Dosyaları İncele";
            this.bReceiver.UseVisualStyleBackColor = true;
            this.bReceiver.Click += new System.EventHandler(this.bReceiver_Click);
            // 
            // bSender
            // 
            this.bSender.Location = new System.Drawing.Point(212, 15);
            this.bSender.Margin = new System.Windows.Forms.Padding(4);
            this.bSender.Name = "bSender";
            this.bSender.Size = new System.Drawing.Size(188, 28);
            this.bSender.TabIndex = 1;
            this.bSender.Text = "Dosya Gönder";
            this.bSender.UseVisualStyleBackColor = true;
            this.bSender.Click += new System.EventHandler(this.bSender_Click);
            // 
            // UserScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 53);
            this.Controls.Add(this.bSender);
            this.Controls.Add(this.bReceiver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "UserScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bReceiver;
        private System.Windows.Forms.Button bSender;
    }
}