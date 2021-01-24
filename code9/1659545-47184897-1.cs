    private byte[] SignData(X509Certificate2 certificate, byte[] dataToSign)
    {
        // get xml params from current private key
        var rsa = (RSA)certificate.PrivateKey;
        var xml = RSAHelper.ToXmlString(rsa, true);
        var parameters = RSAHelper.GetParametersFromXmlString(rsa, xml);
        // generate new private key in correct format
        var cspParams = new CspParameters()
        {
            ProviderType = 24,
            ProviderName = "Microsoft Enhanced RSA and AES Cryptographic Provider"
        };
        var rsaCryptoServiceProvider = new RSACryptoServiceProvider(cspParams);
        rsaCryptoServiceProvider.ImportParameters(parameters);
        // sign data
        var signedBytes = rsaCryptoServiceProvider.SignData(dataToSign, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        return signedBytes;
    }
