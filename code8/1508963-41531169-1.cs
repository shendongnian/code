    using (var reader = File.OpenText("mykey.key"))
    {
        var pem = new PemReader(reader);
        var o = (RsaKeyParameters)pem.ReadObject();
        using (var rsa = new RSACryptoServiceProvider())
        {
            var parameters = new RSAParameters();
            parameters.Modulus = o.Modulus.ToByteArray();
            parameters.Exponent = o.Exponent.ToByteArray();
            rsa.ImportParameters(parameters);
            // Do what you need to do with the RSACryptoServiceProvider instance
        }
    }
