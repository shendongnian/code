             private static Stream EncryptRijndael(byte[] key, byte[] iv, Stream plainText)
        {
            if (plainText == null)
                return null;
            byte[] buffer = new byte[5120 * 1024];
            RijndaelManaged rjndl = RijndaelManagedWithConfig(key, iv);
            using (var memoryStream = new MemoryStream())
            {
                int readedBytes;
                using (var cs = new CryptoStream(memoryStream, rjndl.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                {
                    while ((readedBytes = (plainText.Read(buffer, 0, buffer.Length))) > 0)
                    {
                        cs.Write(buffer, 0, readedBytes);
                    }
                }
                using (var cryptoMemoryStream = new MemoryStream(memoryStream.ToArray()))
                {
                    using (var base64MemoryStream = new MemoryStream())
                    {
                        using (ICryptoTransform transform = new ToBase64Transform())
                        {
                            using (var cryptStream = new CryptoStream(base64MemoryStream, transform, CryptoStreamMode.Write))
                            {
                                while ((readedBytes = cryptoMemoryStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    cryptStream.Write(buffer, 0, readedBytes);
                                }
                                cryptStream.FlushFinalBlock();
                            }
                            return new MemoryStream(base64MemoryStream.ToArray());
                        }
                    }
                }
            }
        }
