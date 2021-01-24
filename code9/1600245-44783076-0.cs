        public static byte[] EncryptAES(byte[] message, byte[] key, bool doEncryption)
        {
            try
            {
                Aes aes = new AesManaged();
                aes.Key = key;
                aes.IV = new byte[16];
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.None;
                ICryptoTransform cipher;
                if (doEncryption == true)
                    cipher = aes.CreateEncryptor();
                else
                    cipher = aes.CreateDecryptor();
                return cipher.TransformFinalBlock(message, 0, message.Length);
            }
            catch(Exception)
            {
                return null;
            }
        }
