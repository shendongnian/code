    public static string EncryptSecret { get; set; }
            static string appId = "Application ID";
            static string secretKey = "Secert key";
            static string tenantId = "TenantId";
    
            public static async Task<string> GetAccessToken(string azureTenantId,string azureAppId,string azureSecretKey)
            {
    
                var context = new AuthenticationContext("https://login.windows.net/" + tenantId);
                ClientCredential clientCredential = new ClientCredential(appId, secretKey);
                var tokenResponse =await context.AcquireTokenAsync("https://vault.azure.net", clientCredential);
                var accessToken = tokenResponse.AccessToken;
                return accessToken;
            }
