        public String Decrypt(string cipherText)
        {
            var result = "";
            var cypher = Convert.FromBase64String(cipherText);
            var encoding = System.Text.Encoding.UTF8;
            var Key = encoding.GetBytes("M2AZULUALPHA"); 
            var IV = encoding.GetBytes("TripBuilder2017"); 
            using (var rj = new RijndaelManaged())
            {
                rj.Padding = PaddingMode.PKCS7;
                rj.Mode = CipherMode.CBC;
                rj.KeySize = 256;
                rj.BlockSize = 256;
                rj.Key = Key;
                rj.IV = IV;
                var ms = new MemoryStream(cypher);
                using (var cs = new CryptoStream(ms, rj.CreateDecryptor(Key, IV), CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                    result = sr.ReadToEnd();
            }
            return result;
        }
