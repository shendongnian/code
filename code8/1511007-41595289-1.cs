    public static byte[] DecryptDataOaepSha1(X509Certificate2 cert, byte[] data)
    {
        using (RSA rsa = cert.GetRSAPublicKey())
        {
            return rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA1);
        }
    }
