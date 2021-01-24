    public static void Main()
    {
        var f = @"q:\test.txt";
        AesCryptoServiceProvider AES = new AesCryptoServiceProvider();
        AES.Padding = PaddingMode.PKCS7;
        AES.Mode = CipherMode.CBC;
        AES.BlockSize = 128;
        AES.KeySize = 128;
        AES.GenerateKey();
        AES.GenerateIV();
        var key = AES.Key;
        var iv = AES.IV;
        encryptAES(AES, f, key, iv);
        decryptAES(AES, f + ".encrypted", key, iv);
    }
    static void encryptAES(SymmetricAlgorithm algo, string filePath, byte[] key, byte[] IV)
    {
            using (FileStream fin = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fout = new FileStream(filePath + ".encrypted", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (ICryptoTransform crypt = algo.CreateEncryptor(key, IV))
                    {
                        using (CryptoStream crStream = new CryptoStream(fout, crypt, CryptoStreamMode.Write))
                        {
                            fin.CopyTo(crStream);
                        }
                    }
                }
            }
    }
    static void decryptAES(SymmetricAlgorithm algo, string filePath, byte[] key, byte[] IV)
    {
            using (FileStream fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (ICryptoTransform crypt = algo.CreateDecryptor(key, IV))
                {
                    using (CryptoStream crStream = new CryptoStream(fStream, crypt, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(crStream))
                        {                  
                            string data = reader.ReadToEnd();
                            File.WriteAllText(filePath.Replace(".encrypted", ".restored"), data);
                        }
                    }
                }
            }
    }
