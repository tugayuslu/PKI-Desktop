using System;
using System.IO;
using System.Security.Cryptography;

namespace VeriGuvenligi_AES_RSA_Hash
{
    public static class AES
    {
        //AES için başlangıçta yapılacak xor için IV değeri sabit olarak belirlenir
        private static byte[] iv = new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        //Her oturum için AES anahtarı oluşturulur
        public static byte[] generateKey()
        {
            try
            {
                using (var aes = Aes.Create())
                {
                    aes.GenerateKey();
                    return aes.Key;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //AES şifreleme işlemi yapılır
        public static void encrypt(string data, byte[] key, string target)
        {
            try
            {
                using (var aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                    {
                        performCryptography(data, encryptor, target);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //AES deşifreleme işlemi yapılır
        public static void decrypt(string data, byte[] key, string target)
        {
            try
            {
                using (var aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    {
                        performCryptography(data, decryptor, target);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //AES'te şifreleme ya da deşifreleme için kullanılan dosya işlemleri yapılır
        private static void performCryptography(string data, ICryptoTransform cryptoTransform, string target)
        {
            try
            {
                using (FileStream destination = new FileStream(target, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(destination, cryptoTransform, CryptoStreamMode.Write))
                    {
                        using (FileStream source = new FileStream(data, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            source.CopyTo(cryptoStream);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //AES şifreleme işlemi yapılır(overload)
        public static void encrypt(byte[] data, byte[] key, string target)
        {
            try
            {
                using (var aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                    {
                        performCryptography(data, encryptor, target);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //AES deşifreleme işlemi yapılır(overload)
        public static void decrypt(byte[] data, byte[] key, string target)
        {
            try
            {
                using (var aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    {
                        performCryptography(data, decryptor, target);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //AES'te şifreleme ya da deşifreleme için kullanılan dosya işlemleri yapılır(overload)
        private static void performCryptography(byte[] data, ICryptoTransform cryptoTransform, string target)
        {
            try
            {
                using (var ms = File.OpenWrite(target))
                {
                    using (var cryptoStream = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(data, 0, data.Length);
                        cryptoStream.FlushFinalBlock();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}