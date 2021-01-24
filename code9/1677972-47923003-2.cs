    private static AesManaged Create(byte[] key)
    {
        var aes = new AesManaged();
        aes.Mode = CipherMode.ECB;
        aes.BlockSize = 128;
        aes.KeySize = 128;
        aes.Padding = PaddingMode.Zeros;
        aes.Key = key;
        return aes;
    }
    private static byte[] AES_encrypt_block(byte[] plainText, byte[] key)
    {
        using (AesManaged aes = Create(key))
        {
            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            return encryptor.TransformFinalBlock(plainText, 0, plainText.Length);
        }
    }
    private static byte[] AES_decrypt_block(byte[] plainText, byte[] key)
    {
        using (AesManaged aesAlg = Create(key))
        {
            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            return decryptor.TransformFinalBlock(plainText, 0, plainText.Length);
        }
    }
