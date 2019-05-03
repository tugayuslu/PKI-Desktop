using System;
using System.IO;
using System.Security.Cryptography;

namespace VeriGuvenligi_AES_RSA_Hash
{
    public static class Hash
    {
        //SHA512 ile dosyanın özütü oluşturulur
        public static byte[] SHA512(string bytes)
        {
            try
            {
                using (var sha512 = new SHA512CryptoServiceProvider())
                {
                    using (FileStream destination = new FileStream(bytes, FileMode.Open, FileAccess.Read))
                    {
                        return sha512.ComputeHash(destination);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Özütlerin tutulduğu byte dizilerinin eşitlik kontrolü yapılır
        public static bool check(byte[] bytes, byte[] bytes2)
        {
            if (bytes.Length == bytes2.Length)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    if (bytes[i] != bytes2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}