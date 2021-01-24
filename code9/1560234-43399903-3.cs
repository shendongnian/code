    class Program
    {
        private static string _password = "0B6854E7-20AA-4B0E-978A-410152AA1B41";
        static void Main(string[] args)
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;
            var salt = "Pa$$w0rd";
            var plainConnection = DecryptRijndael(connection, salt);
            //var encrypted = EncryptRijndael(connection, salt);
        }
        public static string EncryptRijndael(string text, string salt)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("text");
            using(var aesAlg = NewRijndaelManaged(salt))
            using(var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                using (var swEncrypt = new StreamWriter(csEncrypt))
                    swEncrypt.Write(text);
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
        public static string DecryptRijndael(string cipherText, string salt)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");
            if (!IsBase64String(cipherText))
                throw new Exception("The cipherText input parameter is not base64 encoded");
            using (var aesAlg = NewRijndaelManaged(salt))
            using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
            {
                var cipher = Convert.FromBase64String(cipherText);
                using (var msDecrypt = new MemoryStream(cipher))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new StreamReader(csDecrypt))
                    return srDecrypt.ReadToEnd();
            }
        }
        private static bool IsBase64String(string base64String)
        {
            base64String = base64String.Trim();
            return (base64String.Length % 4 == 0) &&
                   Regex.IsMatch(base64String, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }
        private static RijndaelManaged NewRijndaelManaged(string salt)
        {
            if (salt == null) throw new ArgumentNullException("salt");
            var saltBytes = Encoding.ASCII.GetBytes(salt);
            using (var key = new Rfc2898DeriveBytes(_password, saltBytes))
            {
                var aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);
                return aesAlg;
            }
        }
    }
