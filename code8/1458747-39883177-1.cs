    public static string EncripytParameters(string prameters)
    {
        if (String.IsNullOrEmpty(prameters))
        {
            throw new ArgumentNullException
                   ("The string which needs to be encrypted can not be null.");
        }
        byte[] keyBytes = Encoding.UTF8.GetBytes(Key).Take(8).ToArray();
        DES cryptoProvider = new DESCryptoServiceProvider()
        {
            Mode = CipherMode.ECB,
            Key = keyBytes
        };
        var cryptoObject = cryptoProvider.CreateEncryptor();
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoObject, CryptoStreamMode.Write);
        byte[] tempArray = Encoding.UTF8.GetBytes(prameters);
        cryptoStream.Write(tempArray, 0, prameters.Length);
        cryptoStream.FlushFinalBlock();
        var outputData = memoryStream.ToArray();
        string encryptedParameters = Convert.ToBase64String(outputData);
        return Uri.EscapeDataString(encryptedParameters);
    }
