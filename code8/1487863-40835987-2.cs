    const string KEY_STRING = "MOGO_APP";
    public static byte[] decrypt(byte[] encrypt)
    {
        byte[] key = Encoding.ASCII.GetBytes(KEY_STRING);
        DESCryptoServiceProvider cp = new DESCryptoServiceProvider();
        cp.Mode = CipherMode.ECB;
        cp.Key = bytes;
        ICryptoTransform i = cp.CreateDecryptor();
        return i.TransformFinalBlock(encrypt, 0, encrypt.Length); 
    }
