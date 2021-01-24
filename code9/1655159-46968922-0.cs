    public class AzureAuthenticationProviderTest : IAuthenticationProvider
        {
            string accessToken = string.Empty;
            public AzureAuthenticationProviderTest(string accessToken) {
                this.accessToken = accessToken;
    
            }
    
            public async Task AuthenticateRequestAsync(HttpRequestMessage request)
            {
                try
                {
    
                    // Append the access token to the request.
                    request.Headers.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
                }
                catch (Exception ex)
                {
                }
            }
        }
