    public static byte[] decrypt(byte[] encrypt)
    {
        byte[] key = Encoding.ASCII.GetBytes(KEY_STRING);
        DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
        cryptoProvider.Mode = CipherMode.ECB;
        cryptoProvider.Key = bytes;
        ICryptoTransform i = cryptoProvider.CreateDecryptor();
        return i.TransformFinalBlock(encrypt, 0, encrypt.Length); 
    }&#xD;
