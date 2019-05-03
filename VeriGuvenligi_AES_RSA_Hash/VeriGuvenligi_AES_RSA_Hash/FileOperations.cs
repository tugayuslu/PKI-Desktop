using System;
using System.IO;
using System.Windows.Forms;

namespace VeriGuvenligi_AES_RSA_Hash
{
    public static class FileOperations
    {
        private static string name;

        //Dosyalar diğer kullanıcılara gerekli işlemler yapılarak gönderilir
        //0 imzalanarak dosya gönderimi yapılır
        //1 şifrelenerek dosya gönderimi yapılır
        //2 imzalanarak ve şifrelenerek dosya gönderimi yapılır
        public static void senderOperations(string sName, string rName, int methodIndex, string users)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    name = Path.GetFileName(ofd.FileName);
                    if (methodIndex == 0)
                    {
                        string path = "\\0" + randomNameGenerator();
                        Directory.CreateDirectory(users + rName + path);
                        //Dosya Aynen Kopyalanır
                        File.Copy(ofd.FileName, users + rName + path + "\\" + name);
                        //Pbsender kopyalanır
                        File.Copy(users + sName + "\\pub.cert", users + rName + path + "\\" + sName + ".cert");
                        //Prsender ile özüt imzalanır
                        string sPrivKey = users + sName + "\\priv.cert";
                        RSA.signData(sPrivKey, ofd.FileName, users + rName + path + "\\signedhash.sh");
                        MessageBox.Show("Dosya imzalanarak alıcıya iletilmiştir.");
                    }
                    else if (methodIndex == 1)
                    {
                        string path = "\\1" + randomNameGenerator();
                        Directory.CreateDirectory(users + rName + path);
                        byte[] key = AES.generateKey();
                        //Simetrik ile mesaj şifrelenir
                        AES.encrypt(ofd.FileName, key, users + rName + path + "\\" + name);
                        //Simetrik key Pbreceiver ile şifrelenir
                        string rPubKey = users + rName + "\\pub.cert";
                        RSA.encrypt(rPubKey, key, users + rName + path + "\\encryptedsymkey.esk");
                        //Özüt Pbreceiver ile şifrelenir
                        byte[] hash = Hash.SHA512(ofd.FileName);
                        RSA.encrypt(rPubKey, hash, users + rName + path + "\\encryptedhash.eh");
                        //Pbsender kopyalanır
                        File.Copy(users + sName + "\\pub.cert", users + rName + path + "\\" + sName + ".cert");
                        MessageBox.Show("Dosya şifrelenerek alıcıya iletilmiştir.");
                    }
                    else if (methodIndex == 2)
                    {
                        string path = "\\2" + randomNameGenerator();
                        Directory.CreateDirectory(users + rName + path);
                        byte[] key = AES.generateKey();
                        //Pbsender kopyalanır
                        File.Copy(users + sName + "\\pub.cert", users + rName + path + "\\" + sName + ".cert");
                        //Simetrik key Pbreceiver ile şifrelenir
                        string rPubKey = users + rName + "\\pub.cert";
                        RSA.encrypt(rPubKey, key, users + rName + path + "\\encryptedsymkey.esk");
                        //Prsender ile özüt imzalanır ve simetrik ile şifrelenir
                        string sPrivKey = users + sName + "\\priv.cert";
                        byte[] signedHash = RSA.signData(sPrivKey, ofd.FileName);
                        AES.encrypt(signedHash, key, users + rName + path + "\\encryptedsignedhash.esh");
                        //Simetrik ile mesaj şifrelenir
                        AES.encrypt(ofd.FileName, key, users + rName + path + "\\" + name);
                        MessageBox.Show("Dosya imzalanarak ve şifrelenerek alıcıya iletilmiştir.");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        //Alınan dosyalar gerekli işlemler uygulandıktan sonra başarılıysa kaydedilir, değilse veriye ait tüm dosyalar silinir
        //0 imzalanarak gelen dosyaya işlem uygulanır
        //1 şifrelenerek gelen dosyaya işlem uygulanır
        //2 imzalanarak ve şifrelenerek gelen dosyaya işlem uygulanır
        public static void receiverOperations(string rName, string fName, string users)
        {
            try
            {
                if (Directory.Exists(users + rName + "\\" + fName))
                {
                    string[] paths = Directory.GetFiles(users + rName + "\\" + fName);

                    if (fName[0] == '0')
                    {
                        string senderPublicKey = "";
                        string signedHash = "";
                        string originalMessage = "";
                        //Gelen dosyaların ilgili değişkenlere atanması yapılır
                        for (int i = 0; i < paths.Length; i++)
                        {
                            if (Path.GetExtension(paths[i]) == ".cert")
                            {
                                senderPublicKey = paths[i];
                            }
                            else if ((Path.GetExtension(paths[i]) == ".sh"))
                            {
                                signedHash = paths[i];
                            }
                            else
                            {
                                originalMessage = paths[i];
                            }
                        }
                        //Gelen dosyaların varlığını kontrol ederek işlem başlatılır
                        if (File.Exists(senderPublicKey) && File.Exists(signedHash) && File.Exists(originalMessage) && paths.Length == 3)
                        {
                            //İmzalanan özütün ve gönderilen dosyanın gönderen tarafından olup olmadığı ve
                            //dosyanın tamlığının doğrulaması yapılır
                            if (RSA.verifyMessage(originalMessage, signedHash, senderPublicKey))
                            {
                                MessageBox.Show("Doğrulama başarılı.\nDosyanın kaydedileceği konumu seçiniz.");
                                FolderBrowserDialog fbd = new FolderBrowserDialog();
                                if (DialogResult.OK == fbd.ShowDialog())
                                {
                                    //Doğrulama başarılıysa gönderilen dosyanın seçilen dosya yoluna kopyalanması yapılır
                                    File.Copy(originalMessage, fbd.SelectedPath + "\\" + Path.GetFileName(originalMessage), true);
                                    //Geçici olan dosyalar silinir
                                    Directory.Delete(users + rName + "\\" + fName, true);
                                    MessageBox.Show("Dosya kaydedildi.");
                                }
                            }
                            else
                            {
                                //Geçici olan dosyalar silinir
                                Directory.Delete(users + rName + "\\" + fName, true);
                                MessageBox.Show("Doğrulama Başarısız. Dosya imha ediliyor.");
                            }
                        }
                        else
                        {
                            //Geçici olan dosyalar silinir
                            Directory.Delete(users + rName + "\\" + fName, true);
                            MessageBox.Show("Doğrulama Başarısız. Dosya imha ediliyor.");
                        }
                    }
                    else if (fName[0] == '1')
                    {
                        string senderPublicKey = "";
                        string encryptedSymKey = "";
                        string encryptedHash = "";
                        string encryptedMessage = "";
                        byte[] key = new byte[0];
                        byte[] originalMessage = new byte[0];
                        byte[] hash = new byte[0];
                        byte[] hash2 = new byte[0];
                        //Gelen dosyaların ilgili değişkenlere atanması yapılır
                        for (int i = 0; i < paths.Length; i++)
                        {
                            if (Path.GetExtension(paths[i]) == ".cert")
                            {
                                senderPublicKey = paths[i];
                            }
                            else if ((Path.GetExtension(paths[i]) == ".esk"))
                            {
                                encryptedSymKey = paths[i];
                            }
                            else if ((Path.GetExtension(paths[i]) == ".eh"))
                            {
                                encryptedHash = paths[i];
                            }
                            else
                            {
                                encryptedMessage = paths[i];
                            }
                        }
                        //Gelen dosyaların varlığını kontrol ederek işlem başlatılır
                        if (File.Exists(senderPublicKey) && File.Exists(encryptedSymKey) && File.Exists(encryptedHash) && File.Exists(encryptedMessage) && paths.Length == 4)
                        {
                            string rPrivKey = users + rName + "\\priv.cert";
                            //RSA ile şifrelenmiş AES anahtarı deşifrelenir
                            key = RSA.decrypt(rPrivKey, encryptedSymKey);
                            //RSA ile şifrelenmiş özüt deşifrelenir
                            hash = RSA.decrypt(rPrivKey, encryptedHash);
                            //Deşifrelenen AES anahtarı ile şifreli mesaj deşifrelenir
                            AES.decrypt(encryptedMessage, key, users + "tmp");
                            //Deşifreli mesajın özütü ve gelen özüt değeri ile dosyanın doğrulaması yapılır
                            if (Hash.check(hash, Hash.SHA512(users + "tmp")))
                            {
                                MessageBox.Show("Dosya deşifre edildi.\nDosyanın kaydedileceği konumu seçiniz.");
                                FolderBrowserDialog fbd = new FolderBrowserDialog();
                                if (DialogResult.OK == fbd.ShowDialog())
                                {
                                    //Deşifreleme başarılıysa gönderilen dosyanın seçilen dosya yoluna kopyalanması yapılır
                                    File.Copy(users + "tmp", fbd.SelectedPath + "\\" + Path.GetFileName(encryptedMessage), true);
                                    //Geçici olan dosyalar silinir
                                    Directory.Delete(users + rName + "\\" + fName, true);
                                    File.Delete(users + "tmp");
                                    MessageBox.Show("Dosya kaydedildi.");
                                }
                                else
                                {
                                    //Geçici olan dosyalar silinir
                                    File.Delete(users + "tmp");
                                }
                            }
                            else
                            {
                                //Geçici olan dosyalar silinir
                                Directory.Delete(users + rName + "\\" + fName, true);
                                File.Delete(users + "tmp");
                                MessageBox.Show("Dosya deşifre edilemedi. Dosya imha ediliyor.");
                            }
                        }
                        else
                        {
                            //Geçici olan dosyalar silinir
                            Directory.Delete(users + rName + "\\" + fName, true);
                            MessageBox.Show("Dosya deşifre edilemedi. Dosya imha ediliyor.");
                        }
                    }
                    else if (fName[0] == '2')
                    {
                        string senderPublicKey = "";
                        string encryptedSymKey = "";
                        string encryptedSignedHash = "";
                        string encryptedMessage = "";
                        byte[] key = new byte[0];
                        byte[] originalMessage = new byte[0];
                        byte[] signedHash = new byte[0];
                        byte[] hash2 = new byte[0];
                        //Gelen dosyaların ilgili değişkenlere atanması yapılır
                        for (int i = 0; i < paths.Length; i++)
                        {
                            if (Path.GetExtension(paths[i]) == ".cert")
                            {
                                senderPublicKey = paths[i];
                            }
                            else if ((Path.GetExtension(paths[i]) == ".esh"))
                            {
                                encryptedSignedHash = paths[i];
                            }
                            else if ((Path.GetExtension(paths[i]) == ".esk"))
                            {
                                encryptedSymKey = paths[i];
                            }
                            else
                            {
                                encryptedMessage = paths[i];
                            }
                        }
                        //Gelen dosyaların varlığını kontrol ederek işlem başlatılır
                        if (File.Exists(senderPublicKey) && File.Exists(encryptedSymKey) && File.Exists(encryptedSignedHash) && File.Exists(encryptedMessage) && paths.Length == 4)
                        {
                            string rPrivKey = users + rName + "\\priv.cert";
                            //RSA ile şifrelenmiş AES anahtarı deşifrelenir
                            key = RSA.decrypt(rPrivKey, encryptedSymKey);
                            //Deşifrelenen AES anahtarı ile şifreli mesaj deşifrelenir
                            AES.decrypt(encryptedMessage, key, users + "tmp");
                            //Deşifrelenen AES anahtarı ile şifreli ve imzalı özüt deşifrelenir
                            AES.decrypt(encryptedSignedHash, key, users + "tmp2");
                            //Deşifreli mesajın özütü ve gelen imzalı özüt değeri ile dosyanın doğrulaması yapılır
                            if (RSA.verifyMessage(users + "tmp", users + "tmp2", senderPublicKey))
                            {
                                MessageBox.Show("Doğrulama başarılı. Dosya deşifre edildi.\nDosyanın kaydedileceği konumu seçiniz.");

                                FolderBrowserDialog fbd = new FolderBrowserDialog();
                                if (DialogResult.OK == fbd.ShowDialog())
                                {
                                    //Deşifreleme ve doğrulama başarılıysa gönderilen dosyanın seçilen dosya yoluna kopyalanması yapılır
                                    File.Copy(users + "tmp", fbd.SelectedPath + "\\" + Path.GetFileName(encryptedMessage));
                                    //Geçici olan dosyalar silinir
                                    Directory.Delete(users + rName + "\\" + fName, true);
                                    File.Delete(users + "tmp");
                                    File.Delete(users + "tmp2");
                                    MessageBox.Show("Dosya kaydedildi.");
                                }
                                else
                                {
                                    //Geçici olan dosyalar silinir
                                    File.Delete(users + "tmp");
                                    File.Delete(users + "tmp2");
                                }
                            }
                            else
                            {
                                //Geçici olan dosyalar silinir
                                Directory.Delete(users + rName + "\\" + fName, true);
                                File.Delete(users + "tmp");
                                File.Delete(users + "tmp2");
                                MessageBox.Show("Dosyaya müdahale edilmiş. Dosya imha ediliyor.");
                            }
                        }
                        else
                        {
                            //Geçici olan dosyalar silinir
                            Directory.Delete(users + rName + "\\" + fName, true);
                            MessageBox.Show("Dosyaya müdahale edilmiş. Dosya imha ediliyor.");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (File.Exists(users + "tmp"))
                    File.Delete(users + "tmp");
                if (File.Exists(users + "tmp2"))
                    File.Delete(users + "tmp2");
                if (Directory.Exists(users + rName + "\\" + fName))
                    Directory.Delete(users + rName + "\\" + fName, true);
                MessageBox.Show(e.Message);

            }
        }

        //Geçici klasör ismi oluşturulur
        private static string randomNameGenerator()
        {
            string temp = "";
            Random r = new Random();
            for (int i = 0; i < 50; i++)
            {
                temp += r.Next(10);
            }
            return temp;
        }
    }
}