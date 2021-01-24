    static void encryptAES(string filePath, byte[] key, byte[] IV)
    {
        using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider())
        {
            AES.Padding = PaddingMode.PKCS7;
            AES.Key = key;
            AES.BlockSize = 128;
            AES.KeySize = 128;
            AES.IV = IV;
            using (FileStream fin = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fout = new FileStream(filePath + ".encrypted", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (ICryptoTransform crypt = AES.CreateEncryptor(key, IV))
                    {
                        using (CryptoStream crStream = new CryptoStream(fout, crypt, CryptoStreamMode.Write))
                        {
                            fin.CopyTo(crStream);
                        }
                    }
                }
            }
        }
    }
    static void decryptAES(string filePath, byte[] key, byte[] IV)
    {
        using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider())
        {
            AES.Padding = PaddingMode.PKCS7;
            AES.Key = key;
            AES.BlockSize = 128;
            AES.KeySize = 128;
            AES.IV = IV;
            using (FileStream fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (ICryptoTransform crypt = AES.CreateDecryptor(key, IV))
                {
                    using (CryptoStream crStream = new CryptoStream(fStream, crypt, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(crStream))
                        {
                            //breaks here                      
                            string data = reader.ReadToEnd();
                            File.WriteAllText(filePath.Replace(".encrypted", ".restored"), data);
                        }
                    }
                }
            }
        }
    }
    // Testcase
    var f = @"q:\test.txt";
    var key = new byte[16];
    var iv = new byte[16];
    encryptAES(f, key, iv);
    decryptAES(f + ".encrypted", key, iv);
