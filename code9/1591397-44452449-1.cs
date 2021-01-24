        public class AzureAuthenticationProvider : IAuthenticationProvider
        {
            private string _azureDomain = "xxxx.onmicrosoft.com";
            public async Task AuthenticateRequestAsync(HttpRequestMessage request)
            {
              try
              {
                string clientId = "xxxxx-xxxx-xxxx-xxxx-xxxxxxxx";
                string clientSecret = "xxxxxxxxxxxxxxxxxxxxxxxxxx";
                AuthenticationContext authContext = new AuthenticationContext("https://login.windows.net/" + _azureDomain + "/oauth2/token");
                ClientCredential credentials = new ClientCredential(clientId, clientSecret);
                AuthenticationResult authResult = await authContext.AcquireTokenAsync("https://graph.microsoft.com/", credentials);
                request.Headers.Add("Authorization", "Bearer " + authResult.AccessToken);
              }
              catch (Exception ex)
              {
              }
            }
        }
