        public static string GenerateSecret(string username, string token)
        {
            byte[] key;
            using (var md5 = MD5.Create())
            {
                key = md5.ComputeHash(Encoding.UTF8.GetBytes(username));
            }
            key = BytesToLowerHexBytes(key);
            var iv = Convert.FromBase64String(token);
            if (iv.Length != 16)
            {
                Array.Resize(ref iv, 16);
            }
            byte[] encrypted;
            int encryptedLength;
            using (var rijndael = new RijndaelManaged())
            {
                rijndael.Mode = CipherMode.CFB;
                rijndael.Padding = PaddingMode.Zeros;
                rijndael.KeySize = 256;
                using (var msEncrypt = new MemoryStream())
                {
                    var buffer = Encoding.UTF8.GetBytes(token);
                    using (ICryptoTransform encryptor = rijndael.CreateEncryptor(key, iv))
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(buffer, 0, buffer.Length);
                    }
                    // CFB is a stream cipher, where the length of the encrypted text should be
                    // equal to the length of the original text... So we strip the last bytes
                    encrypted = msEncrypt.GetBuffer();
                    encryptedLength = buffer.Length;
                }
            }
            var buffer2 = Encoding.UTF8.GetBytes(Convert.ToBase64String(encrypted, 0, encryptedLength));
            using (var ms = new MemoryStream(iv.Length + buffer2.Length))
            {
                ms.Write(iv, 0, iv.Length);
                ms.Write(buffer2, 0, buffer2.Length);
                return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            }
        }
        public static string ExtractSecret(string username, string encrypted)
        {
            byte[] key;
            using (var md5 = MD5.Create())
            {
                key = md5.ComputeHash(Encoding.UTF8.GetBytes(username));
            }
            key = BytesToLowerHexBytes(key);
            byte[] bytes = Convert.FromBase64String(encrypted);
            byte[] iv = bytes;
            Array.Resize(ref iv, 16);
            byte[] decrypted;
            int decryptedLength;
            using (var rijndael = new RijndaelManaged())
            {
                rijndael.Mode = CipherMode.CFB;
                rijndael.Padding = PaddingMode.Zeros;
                rijndael.KeySize = 256;
                using (var msDecrypt = new MemoryStream())
                {
                    var buffer = Convert.FromBase64String(Encoding.UTF8.GetString(bytes, 16, bytes.Length - 16));
                    using (ICryptoTransform decryptor = rijndael.CreateDecryptor(key, iv))
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                    {
                        csDecrypt.Write(buffer, 0, buffer.Length);
                        // We have to add the remaining bytes of the block. They aren't
                        // important, so we add zeroes
                        int remaining = 16 - (buffer.Length % 16);
                        if (remaining != 0)
                        {
                            csDecrypt.Write(new byte[remaining], 0, remaining);
                        }
                    }
                    // CFB is a stream cipher, where the length of the encrypted text should be
                    // equal to the length of the original text... So we strip the last bytes
                    decrypted = msDecrypt.GetBuffer();
                    decryptedLength = buffer.Length;
                }
            }
            return Encoding.UTF8.GetString(decrypted, 0, decryptedLength);
        }
