    public static string Decrypt(string str, string key)
    {
        try
        {
            key = key.Replace(Environment.NewLine, "");
            IBuffer keyBuffer = CryptographicBuffer.DecodeFromBase64String(key);
            AsymmetricKeyAlgorithmProvider provider = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithmNames.RsaSignPkcs1Sha256);
            CryptographicKey publicKey = provider.ImportPublicKey(keyBuffer, CryptographicPublicKeyBlobType.X509SubjectPublicKeyInfo);
            IBuffer dataBuffer = CryptographicBuffer.CreateFromByteArray(Encoding.UTF8.GetBytes(str));
            var encryptedData = CryptographicEngine.Decrypt(publicKey, dataBuffer, null);
            return CryptographicBuffer.EncodeToBase64String(encryptedData);
        }
        catch (Exception e)
        {
            throw;
            return "Error in Decryption:With RSA ";
        }
    }
