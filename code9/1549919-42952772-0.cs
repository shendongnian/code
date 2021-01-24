    public async Task<IActionResult> MakeRequest()
    {
        string result;
        var oauth = new Oauth.Manager();
        // _tradeKing is a configuration object I set up to hold user secrets
        oauth["consumer_key"] = _tradeKing.ConsumerKey;
        oauth["consumer_secret"] = _tradeKing.ConsumerSecret;
        oauth["token"] = _tradeKing.OauthToken;
        oauth["token_secret"] = _tradeKing.OauthTokenSecret;
        var url = "https://api.tradeking.com/v1/accounts.json";
        var authzHeader = oauth.GenerateAuthzHeader(url, "GET");
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.Headers["Authorization"] = authzHeader;
        var response = await request.GetResponseAsync();
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
            result = reader.ReadToEnd();
        }
        return Content(result);
    }
