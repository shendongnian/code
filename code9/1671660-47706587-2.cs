    public static HttpClient GetProxy()
    {
        // First create a proxy object
        var proxyUri = $"{proxyServerSettings.Address}:{proxyServerSettings.Port}";
        var proxyCreds = new NetworkCredential("proxyuser", "proxypassword");
        var proxy = new WebProxy(proxyUri, false)
        {
            UseDefaultCredentials = false,
            Credentials = proxyCreds,
        };
        // Now create a client handler which uses that proxy
        var httpClientHandler = new HttpClientHandler()
        {
            Proxy = proxy,
            PreAuthenticate = true,
            UseDefaultCredentials = false,
        };
        return new HttpClient(httpClientHandler);
    }
