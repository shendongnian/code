    var clientId = "{Your Client Id}";
    var redirectURI = "pw.oauth2:/oauth2redirect";
    var scope = "https://www.googleapis.com/auth/calendar.readonly";
    var SpotifyUrl = $"https://accounts.google.com/o/oauth2/auth?client_id={clientId}&redirect_uri={Uri.EscapeDataString(redirectURI)}&response_type=code&scope={Uri.EscapeDataString(scope)}";
    var StartUri = new Uri(SpotifyUrl);
    var EndUri = new Uri(redirectURI);
    
    // Get Authorization code
    WebAuthenticationResult WebAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, StartUri, EndUri);
    if (WebAuthenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
    {
        var decoder = new WwwFormUrlDecoder(new Uri(WebAuthenticationResult.ResponseData).Query);
        if (decoder[0].Name != "code")
        {
            System.Diagnostics.Debug.WriteLine($"OAuth authorization error: {decoder.GetFirstValueByName("error")}.");
            return;
        }
    
        var autorizationCode = decoder.GetFirstValueByName("code");
       
    
        //Get Access Token
        var pairs = new Dictionary<string, string>();
        pairs.Add("code", autorizationCode);
        pairs.Add("client_id", clientId);
        pairs.Add("redirect_uri", redirectURI);
        pairs.Add("grant_type", "authorization_code");
    
        var formContent = new Windows.Web.Http.HttpFormUrlEncodedContent(pairs);
    
        var client = new Windows.Web.Http.HttpClient();
        var httpResponseMessage = await client.PostAsync(new Uri("https://www.googleapis.com/oauth2/v4/token"), formContent);
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            System.Diagnostics.Debug.WriteLine($"OAuth authorization error: {httpResponseMessage.StatusCode}.");
            return;
        }
    
        string jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
        var jsonObject = Windows.Data.Json.JsonObject.Parse(jsonString);
        var accessToken = jsonObject["access_token"].GetString();
        
    
        //Call Google Calendar API
        using (var httpRequest = new Windows.Web.Http.HttpRequestMessage())
        {
            string calendarAPI = "https://www.googleapis.com/calendar/v3/users/me/calendarList";
    
            httpRequest.Method = Windows.Web.Http.HttpMethod.Get;
            httpRequest.RequestUri = new Uri(calendarAPI);
            httpRequest.Headers.Authorization = new Windows.Web.Http.Headers.HttpCredentialsHeaderValue("Bearer", accessToken);
    
            var response = await client.SendRequestAsync(httpRequest);
    
            if (response.IsSuccessStatusCode)
            {
                var listString = await response.Content.ReadAsStringAsync();
                //TODO
            }
        }
    }
