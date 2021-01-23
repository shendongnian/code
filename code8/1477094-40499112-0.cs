        public static void AesDecrypt(byte[] keyBytes, byte[] ivBytes, Stream dataStream, FileStream outStream)
        {
            dataStream.Position = 0;
            outStream.Position = 0;
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            symmetricKey.Padding = PaddingMode.PKCS7;
            symmetricKey.BlockSize = 128;
            symmetricKey.KeySize = keyBytes.Length == 32 ? 256 : 128;
            
            const int chunkSize = 4096;
            using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, ivBytes))
            {
                using (CryptoStream cryptoStream = new CryptoStream(outStream, decryptor, CryptoStreamMode.Write))
                {
                    
                    while (dataStream.Position != dataStream.Length)
                    {
                        long remainingBytes = dataStream.Length - dataStream.Position;
                        var buffer = chunkSize > remainingBytes
                            ? new byte[(int) remainingBytes]
                            : new byte[chunkSize];
                        var bytesRead = dataStream.Read(buffer, 0, buffer.Length);
                        cryptoStream.Write(buffer, 0, bytesRead);   
                    }
                    cryptoStream.FlushFinalBlock();
                }
            }
            symmetricKey.Clear();
        }
