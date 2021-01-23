    private static rsaEncrypt(string text, string pubKey, string modulus)
    {
        RSAParameters rsaParams = new RSAParameters
        {
            Exponent = hex2Binary(pubKey),
            Modulus = hex2Binary(modulus),
        };
        using (RSA rsa = RSA.Create())
        {
            rsa.ImportParameters(rsaParams);
            return rsa.Encrypt(Encoding.ASCII.GetBytes(text), YOUNEEDTOPICKTHEPADDINGMODE);
        }
    }
