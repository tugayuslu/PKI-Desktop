using System;
using System.Windows.Forms;

namespace VeriGuvenligi_AES_RSA_Hash
{
    public partial class NewUserScreen : Form
    {
        public NewUserScreen()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            this.DialogResult = DialogResult.OK;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
    }
}
