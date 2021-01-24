    private void AesEncrypt(string inputFile, string outputFile, byte[] passwordBytes, byte[] saltBytes)
    { 
        var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
        RijndaelManaged aes = new RijndaelManaged
        {
            KeySize = 256,
            BlockSize = 128,
            Key = key.GetBytes(AES.KeySize / 8),
            IV = key.GetBytes(AES.BlockSize / 8),
            Padding = PaddingMode.Zeros,
            Mode = CipherMode.CBC
        };
        using (var output = File.Create(outputFile))
        {
            using (var crypto = new CryptoStream(output, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                using (var input = File.OpenRead(inputFile))
                {
                    input.CopyTo(crypto);
                }
            }
        }
    }
