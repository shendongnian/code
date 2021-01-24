        static AesCryptoServiceProvider generateAES()
        {
            AesCryptoServiceProvider a = new AesCryptoServiceProvider();
            a.Padding = PaddingMode.PKCS7;
            a.BlockSize = 128;
            a.KeySize = 128;
            a.GenerateIV();
            a.GenerateKey();
            return a;
        }
        static void encryptAES(byte[] filesBytes, string filePath, AesCryptoServiceProvider aes)
        {
            using (FileStream fStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (ICryptoTransform crypt = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    using (CryptoStream csStream = new CryptoStream(fStream, crypt, CryptoStreamMode.Write))
                    {
                        csStream.Write(filesBytes, 0, filesBytes.Length);
                    }
                    try {
                        File.Delete(filePath + ".encrypted");
                        File.Move(filePath, filePath + ".encrypted");
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                }
            }
        }
        static void decryptAES(/*byte[] buffer,*/string filePath, byte[] key, byte[] IV)
        {
            using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider())
            {
                AES.Padding = PaddingMode.PKCS7;
                AES.Key = key;
                AES.BlockSize = 128;
                AES.KeySize = 128;
                AES.IV = IV;
                using (FileStream fStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    using (ICryptoTransform crypt = AES.CreateDecryptor(key, IV))
                    {
                        using (CryptoStream crStream = new CryptoStream(fStream, crypt, CryptoStreamMode.Read))
                        {
                            using (StreamReader reader = new StreamReader(crStream))
                            {
                                //breaks here                      
                                string data = reader.ReadToEnd();
                                File.WriteAllText(filePath.Replace(".encrypted", ""), data);
                            }
                        }
                    }
                }
            }
        }
