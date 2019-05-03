namespace VeriGuvenligi_AES_RSA_Hash
{
    partial class ReceiverScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiverScreen));
            this.bChooseFile = new System.Windows.Forms.Button();
            this.cbFiles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lFrom = new System.Windows.Forms.Label();
            this.lStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bChooseFile
            // 
            this.bChooseFile.Location = new System.Drawing.Point(17, 106);
            this.bChooseFile.Margin = new System.Windows.Forms.Padding(4);
            this.bChooseFile.Name = "bChooseFile";
            this.bChooseFile.Size = new System.Drawing.Size(340, 28);
            this.bChooseFile.TabIndex = 0;
            this.bChooseFile.Text = "Seç";
            this.bChooseFile.UseVisualStyleBackColor = true;
            this.bChooseFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbFiles
            // 
            this.cbFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiles.FormattingEnabled = true;
            this.cbFiles.Location = new System.Drawing.Point(17, 16);
            this.cbFiles.Margin = new System.Windows.Forms.Padding(4);
            this.cbFiles.Name = "cbFiles";
            this.cbFiles.Size = new System.Drawing.Size(340, 24);
            this.cbFiles.TabIndex = 1;
            this.cbFiles.SelectedIndexChanged += new System.EventHandler(this.cbFiles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kimden:";
            // 
            // lFrom
            // 
            this.lFrom.AutoSize = true;
            this.lFrom.Location = new System.Drawing.Point(83, 48);
            this.lFrom.Name = "lFrom";
            this.lFrom.Size = new System.Drawing.Size(65, 17);
            this.lFrom.TabIndex = 3;
            this.lFrom.Text = "asfa facs";
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(83, 75);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(65, 17);
            this.lStatus.TabIndex = 5;
            this.lStatus.Text = "asfa facs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Durum:";
            // 
            // ReceiverScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 145);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFiles);
            this.Controls.Add(this.bChooseFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ReceiverScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bChooseFile;
        private System.Windows.Forms.ComboBox cbFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lFrom;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Label label3;
    }
}