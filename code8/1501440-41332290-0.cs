        public static string EncryptString(string plainText)
        {
            byte[] key, iv;
            byte[] rawKey = Encoding.ASCII.GetBytes("123456789abcdef");
            string encryptionKeyHex = BitConverter.ToString(rawKey);
            byte[] hexKayBytes = FromHex(encryptionKeyHex); // convert to bytes with 'dashes'
            byte[] data = FromHex("30-30-30-30-30-30-30-30-30-30-30-30-30-30-30-30");
            encryptionKeyHex = ByteArrayToHexString(hexKayBytes);
    // modifying key size to match the algorithm validation on key size
            if (encryptionKeyHex.Length < 32)
            {
                while (encryptionKeyHex.Length < 32)
                {
                    encryptionKeyHex += "0";
                }
            }
            var ivOriginal = BitConverter.ToString(data);
            ivOriginal = ivOriginal.Replace("-", "");
            if (ivOriginal.Length < 16)
            {
                while (ivOriginal.Length < 16)
                {
                    ivOriginal += "0";
                }
            }            
            var keyBytes = StringToByteArray(encryptionKeyHex);
            var ivBytes = StringToByteArray(ivOriginal);
            iv = ivBytes;
            key = keyBytes;
            var amAes = new AesManaged();
            amAes.Mode = CipherMode.CBC;
            amAes.Padding = PaddingMode.PKCS7;
            amAes.KeySize = 128;
            amAes.BlockSize = 128;
            amAes.Key = key;
             amAes.IV = iv;
            var icTransformer = amAes.CreateEncryptor();
            var msTemp = new MemoryStream();
            var csEncrypt = new CryptoStream(msTemp, icTransformer, CryptoStreamMode.Write);
            var sw = new StreamWriter(csEncrypt);
            sw.Write(plainText);
            sw.Close();
            sw.Dispose();
            csEncrypt.Clear();
            csEncrypt.Dispose();
            byte[] bResult = msTemp.ToArray();
            string sResult = Convert.ToBase64String(bResult);
            if (System.Diagnostics.Debugger.IsAttached)
            {
                string debugDetails = "";
                debugDetails += "==> INPUT     : " + plainText + Environment.NewLine;
                debugDetails += "==> SECRET    : " + password + Environment.NewLine;
                //debugDetails += "==> SALT      : " + Program.ByteArrayToHexString(salt) + Environment.NewLine;
                debugDetails += "==> KEY       : " + Encoding.ASCII.GetString(amAes.Key) + " (" + amAes.KeySize.ToString() + ")" + Environment.NewLine;
                debugDetails += "==> IV        : " + Encoding.ASCII.GetString(amAes.IV) + Environment.NewLine;
                debugDetails += "==> ENCRYPTED : " + sResult;
                Console.WriteLine(debugDetails);
            }
            return sResult;
        }
        public static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }
        private static string ByteArrayToHexString(byte[] bytes)
        {
            StringBuilder sbHex = new StringBuilder();
            foreach (byte b in bytes)
                sbHex.AppendFormat("{0:x2}", b);
            return sbHex.ToString();
        }
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
