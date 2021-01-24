    var webRequest = WebRequest.Create("http://google.com") as HttpWebRequest;
    if (webRequest != null)
    {
        webRequest.Accept = "*/*";
        webRequest.UserAgent = ".NET";
        webRequest.Method = WebRequestMethods.Http.Post;
        webRequest.ContentType = "application/json";
        webRequest.Host = "coinbase.com";
        webRequest.Headers.Add("ACCESS_KEY", API_KEY);
        webRequest.Headers.Add("ACCESS_SIGNATURE", signature);
        webRequest.Headers.Add("ACCESS_NONCE", nonce);
        //...
    }
