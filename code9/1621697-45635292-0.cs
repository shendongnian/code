    var baseUrl = "http://openapi.etsy.com/v2/listings";
        restClient = new RestClient(baseUrl);
        oAuth = new OAuthBase();
        e1 = new Etsy_portal(consumerKey, consumerSecret);
        string str = e1.GetConfirmUrl(out AccessToken, out AccessTokenSecret);
        e1.ObtainTokenCredentials(AccessToken, AccessTokenSecret, verifiedToken, out PAccessToken, out PAccessTokenSecret);
        sigHasher = new HMACSHA1(new ASCIIEncoding().GetBytes(string.Format("{0}&{1}", consumerSecret, PAccessTokenSecret)));
        string nonce = oAuth.GenerateNonce();
        string timeStamp = oAuth.GenerateTimeStamp();
        string normalizedUrl;
        string normalizedRequestParameters;
        var data = new Dictionary<string, string> {
			{ "title", "This is a test1" },
			{ "description", "Test Description1" },
            { "quantity", "1" },
            { "price", "5" },
            { "is_supply", "false" },
            { "state", "draft" },
            { "when_made", "2010_2017" },
            { "who_made", "i_did" },
            { "shipping_template_id", "43862539760" }
		};
        data.Add("oauth_consumer_key", consumerKey);
        data.Add("oauth_signature_method", "HMAC-SHA1");
        data.Add("oauth_timestamp", timeStamp);
        data.Add("oauth_nonce", nonce); // Required, but Twitter doesn't appear to use it, so "a" will do.
        data.Add("oauth_token", PAccessToken);
        data.Add("oauth_version", "1.0");
        data.Add("oauth_signature", GenerateSignature(baseUrl, data));
        string oAuthHeader = GenerateOAuthHeader(data);
        var formData = new FormUrlEncodedContent(data.Where(kvp => !kvp.Key.StartsWith("oauth_")));
        using (var http = new HttpClient())
        {
            http.DefaultRequestHeaders.Add("Authorization", oAuthHeader);
            var httpResp = http.PostAsync(baseUrl, formData);
            var respBody = httpResp.Result;
        }
