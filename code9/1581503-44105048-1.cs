     class KeyVaultBase
        {
    
            static string _clientId= "xxxxxxxxxxxxx";
            static string _clientSecret = "xxxxxxxxxxxxxxxx";
            static string _tenantId = "xxxxxxxxxxxxxxxx";
            public static async Task<string> GetAccessToken(string azureTenantId, string azureAppId, string azureSecretKey)
            {
    
                var context = new AuthenticationContext("https://login.windows.net/" + _tenantId);
                ClientCredential clientCredential = new ClientCredential(_clientId, _clientSecret);
                var tokenResponse = await context.AcquireTokenAsync("https://vault.azure.net", clientCredential);
                var accessToken = tokenResponse.AccessToken;
                return accessToken;
            }
    
        }
