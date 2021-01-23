    using Newtonsoft.Json;
    using System;
    using System.Text;
    
    namespace Core.Data
    {
        public class AesCrypto<T> : ICrypto<T>
        {
            public string Encrypt(T source, string salt)
            {
                var e = Encoding.UTF8;
                var rawData = e.GetBytes(JsonConvert.SerializeObject(source));
                var cipherData = AESThenHMAC.SimpleEncryptWithPassword(rawData, salt);
                return Convert.ToBase64String(cipherData);
            }
    
            public T Decrypt(string source, string salt)
            {
                var e = Encoding.UTF8;
                var decryptedBytes = AESThenHMAC.SimpleDecryptWithPassword(Convert.FromBase64String(source), salt);
                return JsonConvert.DeserializeObject<T>(e.GetString(decryptedBytes));
            }
        }
    }
