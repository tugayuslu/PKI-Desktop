using System;
using System.IO;
using System.Windows.Forms;

namespace VeriGuvenligi_AES_RSA_Hash
{
    public partial class ReceiverScreen : Form
    {
        string name, users;
        public ReceiverScreen(string name, string users)
        {
            InitializeComponent();
            this.name = name;
            this.users = users;
            takeFiles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Seçilen dosyalara gerekli işlemler uygulanması için receiverOperations'a bilgiler gönderilir
            FileOperations.receiverOperations(name, cbFiles.Text, users);
            takeFiles();
        }

        private void cbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Gelen dosyaya uygulanan işlem belirlenir
                if (cbFiles.Text[0] == '0')
                {
                    lStatus.Text = "İmzalanmış";
                }
                else if (cbFiles.Text[0] == '1')
                {
                    lStatus.Text = "Şifrelenmiş";
                }
                else if (cbFiles.Text[0] == '2')
                {
                    lStatus.Text = "İmzalanmış ve Şifrelenmiş";
                }

                string[] paths = Directory.GetFiles(users + name + "\\" + cbFiles.Text);
                for (int i = 0; i < paths.Length; i++)
                {
                    //Dosyayı gönderen bulunur
                    if (Path.GetExtension(paths[i]) == ".cert")
                    {
                        lFrom.Text = Path.GetFileName(paths[i]).Substring(0, Path.GetFileName(paths[i]).Length - 5);
                        break;
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        //Gelen dosyalar listelenir
        private void takeFiles()
        {
            try
            {
                cbFiles.Items.Clear();
                cbFiles.Text = "";
                string[] paths = Directory.GetDirectories(users + name + "\\");

                for (int j = 0; j < paths.Length; j++)
                {
                    var dir = new DirectoryInfo(paths[j]);
                    cbFiles.Items.Add(dir.Name);
                }

                if (cbFiles.Items.Count != 0)
                {
                    cbFiles.SelectedIndex = 0;
                    bChooseFile.Enabled = true;
                }
                else
                {
                    bChooseFile.Enabled = false;
                    cbFiles.Text = "";
                    lStatus.Text = "";
                    lFrom.Text = "";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}