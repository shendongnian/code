    public class AesCrypto<T> : ICrypto<T>
    {
        public string Encrypt(T source, string key)
        {
            var e = Encoding.UTF8;
            var rawData = e.GetBytes(JsonConvert.SerializeObject(source));
            var cipherData = AESThenHMAC.SimpleEncryptWithPassword(rawData, key);
            return Convert.ToBase64String(cipherData);
        }
    
        public T Decrypt(string source, string key)
        {
            var e = Encoding.UTF8;
            var decryptedBytes = AESThenHMAC.SimpleDecryptWithPassword(Convert.FromBase64String(source), key);
            return JsonConvert.DeserializeObject<T>(e.GetString(decryptedBytes));
        }
    }
