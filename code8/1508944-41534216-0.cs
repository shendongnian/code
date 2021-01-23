    public static async Task<UserProfile> CallGraphAPIOnBehalfOfUser()
    {
        UserProfile profile = null;
        string accessToken = null;
        AuthenticationResult result = null;
    
        //
        // Use ADAL to get a token On Behalf Of the current user.  To do this we will need:
        //      The Resource ID of the service we want to call.
        //      The current user's access token, from the current request's authorization header.
        //      The credentials of this application.
        //      The username (UPN or email) of the user calling the API
        //
        ClientCredential clientCred = new ClientCredential(clientId, appKey);
        var bootstrapContext = ClaimsPrincipal.Current.Identities.First().BootstrapContext as System.IdentityModel.Tokens.BootstrapContext;
        string userName = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Upn) != null ? ClaimsPrincipal.Current.FindFirst(ClaimTypes.Upn).Value : ClaimsPrincipal.Current.FindFirst(ClaimTypes.Email).Value;
        string userAccessToken = bootstrapContext.Token;
        UserAssertion userAssertion = new UserAssertion(bootstrapContext.Token, "urn:ietf:params:oauth:grant-type:jwt-bearer", userName);
    
        string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);
        string userId = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
        AuthenticationContext authContext = new AuthenticationContext(authority, new DbTokenCache(userId));
    
        // In the case of a transient error, retry once after 1 second, then abandon.
        // Retrying is optional.  It may be better, for your application, to return an error immediately to the user and have the user initiate the retry.
        bool retry = false;
        int retryCount = 0;
    
        do
        {
            retry = false;
            try
            {
                result = await authContext.AcquireTokenAsync(graphResourceId, clientCred, userAssertion);
                accessToken = result.AccessToken;
            }
            catch (AdalException ex)
            {
                if (ex.ErrorCode == "temporarily_unavailable")
                {
                    // Transient error, OK to retry.
                    retry = true;
                    retryCount++;
                    Thread.Sleep(1000);
                }
            }
        } while ((retry == true) && (retryCount < 1));
    
        if (accessToken == null)
        {
            // An unexpected error occurred.
            return null;
        }
    
        //
        // Call the Graph API and retrieve the user's profile.
        //
        string requestUrl = String.Format(
            CultureInfo.InvariantCulture,
            graphUserUrl,
            HttpUtility.UrlEncode(tenant));
        HttpClient client = new HttpClient();
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        HttpResponseMessage response = await client.SendAsync(request);
    
        //
        // Return the user's profile.
        //
        if (response.IsSuccessStatusCode)
        {
            string responseString = await response.Content.ReadAsStringAsync();
            profile = JsonConvert.DeserializeObject<UserProfile>(responseString);
            return profile;
        }
    
        // An unexpected error occurred calling the Graph API.  Return a null profile.
        return null;
    }
