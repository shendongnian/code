    string startURL = "https://www.inoreader.com/oauth2/auth?client_id=[CLIENT_ID]&redirect_uri=[REDIRECT_URI]&response_type=code&scope=[OPTIONAL_SCOPES]&state=[CSRF_PROTECTION_STRING]";
    //endURL is the REDIRECT_URI set in your application registration settings
    string endURL = "[REDIRECT_URI]";
    System.Uri startURI = new System.Uri(startURL);
    System.Uri endURI = new System.Uri(endURL);
    
    // Get Authorization code
    var webAuthenticationResult = 
        await Windows.Security.Authentication.Web.WebAuthenticationBroker.AuthenticateAsync( 
        Windows.Security.Authentication.Web.WebAuthenticationOptions.None, 
        startURI, 
        endURI);
    
    if (webAuthenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
    {
        //webAuthenticationResult.ResponseData would like "https://yourredirecturi.com/?code=[AUTHORIZATION_CODE]&state=[CSRF_PROTECTION_STRING]"
        var decoder = new WwwFormUrlDecoder(new Uri(webAuthenticationResult.ResponseData).Query);
        //Get the CSRF_PROTECTION_STRING and check if it matches that one that you send during the consent page redirection.
        if (decoder.GetFirstValueByName("state") == "[CSRF_PROTECTION_STRING]")
        {
            //Get the AUTHORIZATION_CODE
            var autorizationCode = decoder.GetFirstValueByName("code");
    
            //Send a POST request
            var pairs = new Dictionary<string, string>();
            pairs.Add("code", autorizationCode);
            pairs.Add("redirect_uri", [REDIRECT_URI]);
            pairs.Add("client_id", [CLIENT_ID]);
            pairs.Add("client_secret", [CLIENT_SECRET]);
            pairs.Add("scope", [OPTIONAL_SCOPES]);
            pairs.Add("grant_type", "authorization_code");
    
            var formContent = new Windows.Web.Http.HttpFormUrlEncodedContent(pairs);
    
            var client = new Windows.Web.Http.HttpClient();
            var httpResponseMessage = await client.PostAsync(new Uri("https://www.inoreader.com/oauth2/token"), formContent);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                //The Response is a JSON string 
                string jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
                var jsonObject = Windows.Data.Json.JsonObject.Parse(jsonString);
                //Obtaining access and refresh tokens
                var accessToken = jsonObject["access_token"].GetString();
                var refreshToken = jsonObject["refresh_token"].GetString();
            }
        }
    }
