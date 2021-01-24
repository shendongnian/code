    public static byte[] EncryptBytes(byte[] clearBytes, string password)
    {
        using (SymmetricAlgorithm algorithm = GetAlgorithm(password))
        using (ICryptoTransform encryptor = algorithm.CreateEncryptor())
        using (MemoryStream ms = new MemoryStream())
        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        {
            cs.Write(clearBytes, 0, clearBytes.Length);
            cs.FlushFinalBlock();
            return ms.ToArray();
        }
    }
    public static byte[] DecryptBytes(byte[] cipherBytes, string password)
    {
        using (SymmetricAlgorithm algorithm = GetAlgorithm(password))
        using (ICryptoTransform decryptor = algorithm.CreateDecryptor())
        using (MemoryStream ms = new MemoryStream())
        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
        {
            cs.Write(cipherBytes, 0, cipherBytes.Length); //here is the exception thrown
            cs.FlushFinalBlock();
            return ms.ToArray();
        }
    }
