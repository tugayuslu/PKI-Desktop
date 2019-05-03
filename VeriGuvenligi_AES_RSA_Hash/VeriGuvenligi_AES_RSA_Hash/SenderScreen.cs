using System;
using System.IO;
using System.Windows.Forms;

namespace VeriGuvenligi_AES_RSA_Hash
{
    public partial class SenderScreen : Form
    {
        private string name, users;

        public SenderScreen(string name, string users)
        {
            InitializeComponent();
            this.name = name;
            this.users = users;
            cbMethod.SelectedIndex = 0;
            takeUsersNames();
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            //Uygulanacak işlemlerin yapılması için senderOperations'a bilgiler gönderilir
            FileOperations.senderOperations(name, cbReceiver.Text, cbMethod.SelectedIndex, users);
        }

        //Kullanıcılar listelenir
        private void takeUsersNames()
        {
            try
            {
                string[] paths = Directory.GetDirectories(users);

                for (int j = 0; j < paths.Length; j++)
                {
                    var dir = new DirectoryInfo(paths[j]);
                    if (dir.Name != name)
                        cbReceiver.Items.Add(dir.Name);
                }

                if (cbReceiver.Items.Count != 0)
                {
                    cbReceiver.SelectedIndex = 0;
                    bSend.Enabled = true;
                }
                else
                {
                    bSend.Enabled = false;
                    cbReceiver.Text = "";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}