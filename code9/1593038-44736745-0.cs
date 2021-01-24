    public string GetClientCredentialsAuthToken()
        {
            var webClient = new WebClient();
    
            var postparams = new NameValueCollection();
            postparams.Add("grant_type", "client_credentials");
    
            var authHeader = Convert.ToBase64String(Encoding.Default.GetBytes("95da9f399a78...:5a7aaef94..."));   //including clientID and Client Secret
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + authHeader);
    
            var tokenResponse = webClient.UploadValues("https://accounts.spotify.com/api/token", postparams);
    
            var TokenRes = Encoding.UTF8.GetString(tokenResponse);
    
            int pFrom = TokenRes.IndexOf("access_token") + "access_token".Length;
            int pTo = TokenRes.LastIndexOf("token_type");
            string semiToken = TokenRes.Substring(pFrom, pTo - pFrom);
            string myAccessToken = semiToken.Substring(3, semiToken.Length - 6);
    
            return myAccessToken;
        }
