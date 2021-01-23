    public static string DecryptToBytesUsingCBC(byte[] toDecrypt)
            {
                byte[] src = toDecrypt;
                byte[] dest = new byte[src.Length];
                using (var aes = new AesCryptoServiceProvider())
                {
                    aes.BlockSize = 128;
                    aes.KeySize = 128;
                    aes.IV = Encoding.UTF8.GetBytes(AesIV);
                    aes.Key = Encoding.UTF8.GetBytes(AesKey);
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.Zeros;
                    // decryption
                    using (ICryptoTransform decrypt = aes.CreateDecryptor(aes.Key, aes.IV))
                    {
                        byte[] decryptedText = decrypt.TransformFinalBlock(src, 0, src.Length);
                        
                        return Encoding.UTF8.GetString(decryptedText);
                    }
                }
            }
            public static string DecryptUsingCBC(string toDecrypt)
            {
    
                return DecryptToBytesUsingCBC(Convert.FromBase64String(toDecrypt));
            }
