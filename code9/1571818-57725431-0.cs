    public static string Decrypt(string cipherText)
      {
         string EncryptionKey  = string.Empty;
    
        // Check whether the environment variable exists.
        EncryptionKey = Environment.GetEnvironmentVariable("EncryptKey");
    
        if (EncryptionKey == null)
        {
            EncryptionKey = "E546C8DF278CD5931069B522E695D4F2";
        }
                byte[] cipherBytes;
                try
                {
                    cipherBytes = Convert.FromBase64String(cipherText);
                }
                catch
                {
                    return cipherText;
                }
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;
            }
