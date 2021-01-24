            static string appId = "Registried Azure AD Appliction Id";
            static string secretKey = "Client secret Key";
            static string tenantId = "tenant Id ";
            private static string subscriptionId = "subscription Id ";
            public static async Task<string> GetAccessToken(string azureTenantId, string azureAppId, string azureSecretKey)
            {
    
                var context = new AuthenticationContext("https://login.windows.net/" + tenantId);
                ClientCredential clientCredential = new ClientCredential(appId, secretKey);
                var tokenResponse = await context.AcquireTokenAsync("https://management.azure.com/", clientCredential);
                var accessToken = tokenResponse.AccessToken;
                return accessToken;
            }
            static void Main(string[] args)
            {
                TokenCredentials ccCredentials = new TokenCredentials(GetAccessToken(tenantId, appId, secretKey).Result);
                var resourceManagementClient = new ResourceManagementClient(ccCredentials)
                {
                    SubscriptionId = subscriptionId
                };
                var list1 = resourceManagementClient.Providers.List().ToList();
                var resource = resourceManagementClient.Providers.List().ToList().FirstOrDefault(x => x.NamespaceProperty.Equals("TrendMicro.DeepSecurity") && x.RegistrationState.Equals("NotRegistered"));
                var registry =resourceManagementClient.Providers.Register(resource?.NamespaceProperty);
            }
