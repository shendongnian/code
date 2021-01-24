    using (HttpClient client = new HttpClient())
    {
        client.BaseAddress = new Uri("https://api.twitter.com/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        TimeSpan timestamp = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        string nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
        Dictionary<string, string> oauth = new Dictionary<string, string>
        {
            ["oauth_nonce"] = new string(nonce.Where(c => char.IsLetter(c) || char.IsDigit(c)).ToArray()),
            ["oauth_callback"] = "http://my.callback.url",
            ["oauth_signature_method"] = "HMAC-SHA1",
            ["oauth_timestamp"] = Convert.ToInt64(timestamp.TotalSeconds).ToString(),
            ["oauth_consumer_key"] = OAUTH_KEY,
            ["oauth_version"] = "1.0"
        };
        string[] parameterCollectionValues = oauth.Select(parameter =>
                Uri.EscapeDataString(parameter.Key) + "=" +
                Uri.EscapeDataString(parameter.Value))
            .OrderBy(kv => kv)
            .ToArray();
        string parameterCollection = string.Join("&", parameterCollectionValues);
        string baseString = "POST";
        baseString += "&";
        baseString += Uri.EscapeDataString(client.BaseAddress + "oauth/request_token");
        baseString += "&";
        baseString += Uri.EscapeDataString(parameterCollection);
        string signingKey = Uri.EscapeDataString(OAUTH_SECRET);
        signingKey += "&";
        HMACSHA1 hasher = new HMACSHA1(new ASCIIEncoding().GetBytes(signingKey));
        oauth["oauth_signature"] = Convert.ToBase64String(hasher.ComputeHash(new ASCIIEncoding().GetBytes(baseString)));
        string headerString = "OAuth ";
        string[] headerStringValues = oauth.Select(parameter =>
                Uri.EscapeDataString(parameter.Key) + "=" + "\"" +
                Uri.EscapeDataString(parameter.Value) + "\"")
            .ToArray();
        headerString += string.Join(", ", headerStringValues);
        client.DefaultRequestHeaders.Add("Authorization", headerString);
        HttpResponseMessage response = await client.PostAsJsonAsync("oauth/request_token", "");
        var responseString = await response.Content.ReadAsStringAsync();
    }
