using System;
using System.IO;
using System.Security.Cryptography;

namespace VeriGuvenligi_AES_RSA_Hash
{
    public static class RSA
    {
        //Kullanıcıya özel RSA anahtarı oluşturulur
        public static void generateKeysRSA(string users, string name)
        {
            try
            {
                string publicKeyFile = users + name + "\\pub.cert";
                string privateKeyFile = users + name + "\\priv.cert";

                using (var rsa = new RSACryptoServiceProvider(4096))
                {
                    rsa.PersistKeyInCsp = false;
                    //oluşturulan anahtarlar kullanıcıya özel klasöre kaydedilir
                    string publicKey = rsa.ToXmlString(false);
                    File.WriteAllText(publicKeyFile, publicKey);
                    string privateKey = rsa.ToXmlString(true);
                    File.WriteAllText(privateKeyFile, privateKey);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //RSA şifreleme işlemi yapılır ve gönderilecek kullanıcının klasörüne kaydedilir
        public static void encrypt(string keyFile, byte[] data, string target)
        {
            try
            {
                using (var rsa = new RSACryptoServiceProvider(4096))
                {
                    rsa.PersistKeyInCsp = false;
                    string key = File.ReadAllText(keyFile);
                    rsa.FromXmlString(key);
                    File.WriteAllBytes(target, rsa.Encrypt(data, false));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        //RSA deşifreleme işlemi yapılır ve gelen dosya kullanıcının belirlediği klasöre kaydedilir
        public static byte[] decrypt(string keyFile, string encryptedData)
        {
            try
            {
                using (var rsa = new RSACryptoServiceProvider(4096))
                {
                    rsa.PersistKeyInCsp = false;
                    string key = File.ReadAllText(keyFile);
                    rsa.FromXmlString(key);
                    return rsa.Decrypt(File.ReadAllBytes(encryptedData), false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Dosya özütü PrSender ile şifrelenir ve gönderilecek kullanıcının klasörüne kaydedilir
        public static void signData(string keyFile, string dataFile, string target)
        {
            try
            {
                FileStream fStream = File.OpenRead(dataFile);
                using (var rsa = new RSACryptoServiceProvider(4096))
                {
                    string key = File.ReadAllText(keyFile);
                    rsa.FromXmlString(key);
                    File.WriteAllBytes(target, rsa.SignData(fStream, new SHA512CryptoServiceProvider()));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Dosya özütü PrSender ile şifrelenir
        public static byte[] signData(string keyFile, string dataFile)
        {
            try
            {
                FileStream fStream = File.OpenRead(dataFile);
                using (var rsa = new RSACryptoServiceProvider(4096))
                {
                    string key = File.ReadAllText(keyFile);
                    rsa.FromXmlString(key);
                    return rsa.SignData(fStream, new SHA512CryptoServiceProvider());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Dosya özütü PbSender ile deşifrelenir ve orjinal dosyanın özütü ile karşılaştırılır
        public static bool verifyMessage(string originalData, string signedHash, string keyFile)
        {
            try
            {
                byte[] temp = Hash.SHA512(originalData);
                using (var rsa = new RSACryptoServiceProvider(4096))
                {
                    string key = File.ReadAllText(keyFile);
                    rsa.FromXmlString(key);
                    return rsa.VerifyHash(temp, HashAlgorithmName.SHA512.ToString(), File.ReadAllBytes(signedHash));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}