    private static byte[] AES_encrypt_block(byte[] plainText, byte[] Key)
    {
        using (AesManaged aesAlg = new AesManaged())
        {
            aesAlg.Mode = CipherMode.ECB;
            aesAlg.BlockSize = 128;
            aesAlg.KeySize = 128;
            aesAlg.Padding = PaddingMode.PKCS7;
            aesAlg.Key = Key;
    
            // Create a decrytor to perform the stream transform.
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            return encryptor.TransformFinalBlock(plainText, 0, plainText.Length);
        }
    }
