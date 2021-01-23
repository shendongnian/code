    private static async Task<HttpWebRequest> createHttpRequestWithToken(Uri uri)
    {
        HttpWebRequest newRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
        string clientId = ConfigurationManager.AppSettings["ClientId"]);
        string clientSecret = ConfigurationManager.AppSettings["ClientSecret"]);
        ClientCredential creds = new ClientCredential(clientId, clientSecret);
        AuthenticationContext authContext = new AuthenticationContext(string.Format("https://login.microsoftonline.com/{0}/", ConfigurationManager.AppSettings["OrganizationId"]));
        AuthenticationResult authResult = await authContext.AcquireTokenAsync("https://management.core.windows.net/", creds);
        newRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + authResult.AccessToken);     
        return newRequest;
    }
