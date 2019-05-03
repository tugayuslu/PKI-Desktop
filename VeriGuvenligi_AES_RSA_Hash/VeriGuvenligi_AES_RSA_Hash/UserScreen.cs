using System;
using System.Windows.Forms;

namespace VeriGuvenligi_AES_RSA_Hash
{
    public partial class UserScreen : Form
    {
        string users;

        public UserScreen(string name,string users)
        {
            InitializeComponent();
            this.Text = name;
            this.users = users;
        }

        private void bReceiver_Click(object sender, EventArgs e)
        {
            ReceiverScreen rs = new ReceiverScreen(this.Text,users);
            this.Hide();
            rs.ShowDialog();
            this.Show();
        }

        private void bSender_Click(object sender, EventArgs e)
        {
            SenderScreen ss = new SenderScreen(this.Text,users);
            this.Hide();
            ss.ShowDialog();
            this.Show();
        }
    }
}
