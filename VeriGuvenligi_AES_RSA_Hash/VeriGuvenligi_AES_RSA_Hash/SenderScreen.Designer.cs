namespace VeriGuvenligi_AES_RSA_Hash
{
    partial class SenderScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SenderScreen));
            this.bSend = new System.Windows.Forms.Button();
            this.cbReceiver = new System.Windows.Forms.ComboBox();
            this.cbMethod = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(17, 48);
            this.bSend.Margin = new System.Windows.Forms.Padding(4);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(341, 28);
            this.bSend.TabIndex = 0;
            this.bSend.Text = "Gönder";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // cbReceiver
            // 
            this.cbReceiver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReceiver.FormattingEnabled = true;
            this.cbReceiver.Location = new System.Drawing.Point(17, 15);
            this.cbReceiver.Margin = new System.Windows.Forms.Padding(4);
            this.cbReceiver.Name = "cbReceiver";
            this.cbReceiver.Size = new System.Drawing.Size(160, 24);
            this.cbReceiver.TabIndex = 1;
            // 
            // cbMethod
            // 
            this.cbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMethod.FormattingEnabled = true;
            this.cbMethod.Items.AddRange(new object[] {
            "İmzala",
            "Şifrele",
            "İmzala & Şifrele"});
            this.cbMethod.Location = new System.Drawing.Point(197, 15);
            this.cbMethod.Margin = new System.Windows.Forms.Padding(4);
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(160, 24);
            this.cbMethod.TabIndex = 2;
            // 
            // SenderScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 86);
            this.Controls.Add(this.cbMethod);
            this.Controls.Add(this.cbReceiver);
            this.Controls.Add(this.bSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SenderScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.ComboBox cbReceiver;
        private System.Windows.Forms.ComboBox cbMethod;
    }
}