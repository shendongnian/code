    using Org.BouncyCastle.OpenSsl;
    
    private static AsymmetricKeyParameter ReadPrivateKeyFromPemEncodedString(string pemEncodedKey)
    {
        AsymmetricKeyParameter result;
        using (var stringReader = new StringReader(pemEncodedKey))
        {
            var pemReader = new PemReader(stringReader);
            var pemObject = pemReader.ReadObject();
            result = ((AsymmetricCipherKeyPair)pemObject).Private;
        }
    
        return result;
    }
