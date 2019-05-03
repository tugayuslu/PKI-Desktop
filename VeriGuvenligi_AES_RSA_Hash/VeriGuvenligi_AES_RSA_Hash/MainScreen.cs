using System;
using System.IO;
using System.Windows.Forms;

namespace VeriGuvenligi_AES_RSA_Hash
{
    public partial class MainScreen : Form
    {
        private string users = Application.StartupPath + "\\Kullanıcılar\\";

        public MainScreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Kullanıcılar klasörünün varlığını kontrol ettikten sonra yoksa Kullanıcılar klasörü oluşturulur
            if (!Directory.Exists(users)) Directory.CreateDirectory(users);
            takeUsersNames();
        }

        //Kullanıcılar listelenir
        private void takeUsersNames()
        {
            try
            {
                comboBox1.Items.Clear();
                string[] paths = Directory.GetDirectories(users);

                for (int j = 0; j < paths.Length; j++)
                {
                    var dir = new DirectoryInfo(paths[j]);
                    comboBox1.Items.Add(dir.Name);
                }

                if (comboBox1.Items.Count != 0)
                {
                    bLogIn.Enabled = true;
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    comboBox1.Text = "";
                    bLogIn.Enabled = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        //Yeni kullanıcı ve kullanıcıya özel RSA keyleri oluşturulur
        public void CreateNewUser()
        {
            try
            {
                NewUserScreen testDialog = new NewUserScreen();

                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {

                    if (Directory.Exists(users + testDialog.textBox1.Text))
                    {
                        MessageBox.Show("Böyle bir kullanıcı zaten var.");
                    }
                    else
                    {
                        Directory.CreateDirectory(users + testDialog.textBox1.Text);
                        //Kullanıcıya özel RSA keyleri oluşturulur
                        RSA.generateKeysRSA(users, testDialog.textBox1.Text);
                        takeUsersNames();
                        MessageBox.Show("Yeni kullanıcı oluşturuldu.");
                    }
                }

                testDialog.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        private void bCreateNewUser_Click(object sender, EventArgs e)
        {
            CreateNewUser();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            takeUsersNames();
        }

        private void bLogIn_Click(object sender, EventArgs e)
        {

            UserScreen us = new UserScreen(comboBox1.Text, users);
            this.Hide();
            us.ShowDialog();
            this.Show();
        }
    }
}