    public bool IsMessageSignatureValid(byte[] bytes, string signature) {
        // New instance each call? If so, dispose this.
        X509Certificate2 certificate = GetX509Certificate();
        // GetRSAPublicKey returns a new object each time,
        // you should definitely using/Dispose it.
        using (RSA rsa = certificate.GetRSAPublicKey())
        {
            return rsa.VerifyData(
                bytes,
                Convert.FromBase64String(signature),
                HashAlgorithmName.SHA1,
                RSASignaturePadding.Pkcs1);
        }
    }
