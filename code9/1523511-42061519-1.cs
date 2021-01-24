    public static byte[] Encrypt(byte[] data, string publicKey)
    {
        IBuffer buffer = WindowsRuntimeBufferExtensions.AsBuffer(data, 0, data.Length);
        AsymmetricKeyAlgorithmProvider asymmetricAlgorithm = AsymmetricKeyAlgorithmProvider.OpenAlgorithm("RSA_PKCS1");
        try
        {
            CryptographicKey key = asymmetricAlgorithm.ImportPublicKey(CryptographicBuffer.DecodeFromBase64String(publicKey), CryptographicPublicKeyBlobType.Capi1PublicKey);
            IBuffer encrypted = CryptographicEngine.Encrypt(key, buffer, null);
            return encrypted.ToArray();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
            return new byte[0];
        }
    }
    public static byte[] Decrypt(byte[] data, string publicKey, string privateKey)
    {
        IBuffer buffer = WindowsRuntimeBufferExtensions.AsBuffer(data, 0, data.Length);
        AsymmetricKeyAlgorithmProvider asymmetricAlgorithm = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithmNames.RsaPkcs1);
        try
        {
            CryptographicKey pubkey = asymmetricAlgorithm.ImportPublicKey(CryptographicBuffer.DecodeFromBase64String(publicKey), CryptographicPublicKeyBlobType.Capi1PublicKey);
            CryptographicKey keyPair2 = asymmetricAlgorithm.ImportKeyPair(CryptographicBuffer.DecodeFromBase64String(privateKey), CryptographicPrivateKeyBlobType.Capi1PrivateKey);
            IBuffer decrypted = CryptographicEngine.Decrypt(keyPair2, buffer, null);
            return decrypted.ToArray();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
            return new byte[0];
        }
    }
