    private string GetToken()
    {
        var algorithm = "ES256";
        var teamID = "teamID";
        var apnsKeyID = "apnsKeyID";
        var apnsAuthKeyPath = @"apnsAuthKeyPath";
        var epochNow = DateTimeOffset.Now.ToUnixTimeSeconds();
        var header = new Dictionary<string, object>()
        {
            { "alg", algorithm },
            { "kid" , apnsKeyID }
        };
        var payload = new Dictionary<string, object>()
        {
            { "iss", teamID },
            { "iat", epochNow }
        };
        var privateKey = GetPrivateKey(apnsAuthKeyPath);
        var token = Jose.JWT.Encode(payload, privateKey, algorithm: Jose.JwsAlgorithm.ES256, extraHeaders: header);
        return token;
    }
    private CngKey GetPrivateKey(string apnsAuthKey)
    {
        using (var reader = File.OpenText(apnsAuthKey))
        {
            var ecPrivateKeyParameters = (ECPrivateKeyParameters)new PemReader(reader).ReadObject();
            var x = ecPrivateKeyParameters.Parameters.G.AffineXCoord.GetEncoded();
            var y = ecPrivateKeyParameters.Parameters.G.AffineYCoord.GetEncoded();
            var d = ecPrivateKeyParameters.D.ToByteArrayUnsigned();
            return EccKey.New(x, y, d);
        }
    }
