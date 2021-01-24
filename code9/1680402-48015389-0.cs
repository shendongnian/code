    public static void FileEncrypt(string inputFile, string outputFile, string password, byte[] salt)
        {
            try
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    byte[] passwordBytes = ASCIIEncoding.UTF8.GetBytes(password);
                    
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    
                    var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    /* This is for demostrating purposes only. 
                     * Ideally you will want the IV key to be different from your key and you should always generate a new one for each encryption in other to achieve maximum security*/
                    //byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);
                    using (FileStream fsCrypt = new FileStream(outputFile, FileMode.Create))
                    {
                        using (ICryptoTransform encryptor = AES.CreateEncryptor(AES.Key, AES.IV))
                        {
                            using (CryptoStream cs = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                                {
                                    int data;
                                    while ((data = fsIn.ReadByte()) != -1)
                                    {
                                        cs.WriteByte((byte)data);
                                    }
                                    if (!cs.HasFlushedFinalBlock)
                                        cs.FlushFinalBlock();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void FileDecrypt(string inputFile, string outputFile, string password, byte[] salt)
        {
            try
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    //byte[] key = ASCIIEncoding.UTF8.GetBytes(password);
                    /* This is for demostrating purposes only. 
                     * Ideally you will want the IV key to be different from your key and you should always generate a new one for each encryption in other to achieve maximum security*/
                    //byte[] IV = ASCIIEncoding.UTF8.GetBytes(password);
                    byte[] passwordBytes = ASCIIEncoding.UTF8.GetBytes(password);
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    
                    using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
                    {
                        using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                        {
                            using (ICryptoTransform decryptor = AES.CreateDecryptor(AES.Key, AES.IV))
                            {
                                using (CryptoStream cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read))
                                {
                                    int data;
                                    while ((data = cs.ReadByte()) != -1)
                                    {
                                        fsOut.WriteByte((byte)data);
                                    }
                                    if (!cs.HasFlushedFinalBlock)
                                        cs.FlushFinalBlock();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // failed to decrypt file
            }
        }
    }
