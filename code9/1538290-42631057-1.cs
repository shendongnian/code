    private static string GetProviderToken()
    {
        var epochNow = (int) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        var payload = new Dictionary<string, object>()
        {
            {"iss", "your team id"},
            {"iat", epochNow}
        };
        var extraHeaders = new Dictionary<string, object>()
        {
            {"kid", "your key id"}
        };
        var privateKey = GetPrivateKey();
        return JWT.Encode(payload, privateKey, JwsAlgorithm.ES256, extraHeaders);
    }
        
