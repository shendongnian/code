    public async Task<string> GetToken(string authority, string resource, string scope)
    {
     var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(ConfigurationManager.AppSettings["ClientID"], ConfigurationManager.AppSettings["ClientSecret"]);
            AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);
            if(result == null)
            {
                throw new InvalidOperationException("Failed to obtain the JWT Token");
            }
            Console.WriteLine("Retrieved Password");
            return result.AccessToken;
    }
