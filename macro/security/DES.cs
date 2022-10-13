using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace macro
{
    class DES
    {
        public enum DesType
        {
            Encrypt = 0, 
            Decrypt = 1  
        }

        private byte[] Key { get; set; }

        public string result(DesType type, string input)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider()
            {
                Key = Key,
                IV = Key
            };

            MemoryStream ms = new MemoryStream();

            var property = new
            {
                transform = type.Equals(DesType.Encrypt) ? des.CreateEncryptor() : des.CreateDecryptor(),
                data = type.Equals(DesType.Encrypt) ? Encoding.UTF8.GetBytes(input.ToCharArray()) : Convert.FromBase64String(input)
            };

            var cryStream = new CryptoStream(ms, property.transform, CryptoStreamMode.Write);
            var data = property.data;

            cryStream.Write(data, 0, data.Length);
            cryStream.FlushFinalBlock();

            return type.Equals(DesType.Encrypt) ? Convert.ToBase64String(ms.ToArray()) : Encoding.UTF8.GetString(ms.GetBuffer());
        }

        public DES(string key)
        {
            Key = ASCIIEncoding.ASCII.GetBytes(key);
        }
    }
}
