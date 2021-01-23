    using (RSA rsa = cert.GetRSAPrivateKey())
    {
        if (rsa == null)
        {
            throw new Exception("Wasn't an RSA key, or no private key was present");
        }
        bool isValid = rsa.VerifyData(
            Encoding.UTF8.GetBytes(plainText),
            signature,
            HashAlgorithmName.SHA256,
            RSASignaturePadding.Pkcs1);
        if (!isValid)
        {
            throw new Exception("VerifyData failed");
        }
    }
