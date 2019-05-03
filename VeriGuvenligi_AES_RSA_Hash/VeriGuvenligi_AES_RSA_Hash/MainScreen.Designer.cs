namespace VeriGuvenligi_AES_RSA_Hash
{
    partial class MainScreen
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.bCreateNewUser = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bLogIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bCreateNewUser
            // 
            this.bCreateNewUser.Location = new System.Drawing.Point(16, 48);
            this.bCreateNewUser.Margin = new System.Windows.Forms.Padding(4);
            this.bCreateNewUser.Name = "bCreateNewUser";
            this.bCreateNewUser.Size = new System.Drawing.Size(269, 28);
            this.bCreateNewUser.TabIndex = 1;
            this.bCreateNewUser.Text = "Yeni Kullanıcı Oluştur";
            this.bCreateNewUser.UseVisualStyleBackColor = true;
            this.bCreateNewUser.Click += new System.EventHandler(this.bCreateNewUser_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 15);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // bLogIn
            // 
            this.bLogIn.Location = new System.Drawing.Point(185, 15);
            this.bLogIn.Margin = new System.Windows.Forms.Padding(4);
            this.bLogIn.Name = "bLogIn";
            this.bLogIn.Size = new System.Drawing.Size(100, 28);
            this.bLogIn.TabIndex = 3;
            this.bLogIn.Text = "Giriş Yap";
            this.bLogIn.UseVisualStyleBackColor = true;
            this.bLogIn.Click += new System.EventHandler(this.bLogIn_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 88);
            this.Controls.Add(this.bLogIn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bCreateNewUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bCreateNewUser;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bLogIn;
    }
}

