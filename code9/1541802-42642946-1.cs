    public static string EncryptText(string input, string password)
    {
        // Get the bytes of the string
        byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);
        string result = Convert.ToBase64String(bytesEncrypted);
        return result;
    }
    public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = passwordBytes;
                aes.Mode = CipherMode.ECB;
                // "zero" IV
                aes.IV = new byte[16];
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                    cs.Close();
                }
            }
            byte[] encryptedBytes = ms.ToArray();
            return encryptedBytes;
        }
    }
