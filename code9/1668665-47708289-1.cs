     private static async Task<string> GetToken(string tenantId, string clientId, string secretKey)
            {
                var context = new AuthenticationContext("https://login.windows.net/" + tenantId);
                ClientCredential clientCredential = new ClientCredential(clientId, secretKey);
                var tokenResponse = await context.AcquireTokenAsync("https://management.azure.com/", clientCredential); 
                var accessToken = tokenResponse.AccessToken;
                return accessToken;
            }
            var token = GetToken(_tenantId, _clientId, _screctKey).Result;
            TokenCredentials credentials = new TokenCredentials(token);
            DataFactoryManagementClient client = new 
            DataFactoryManagementClient(credentials) { SubscriptionId = subscriptionId };
            DataFactoryManagementClient client = new DataFactoryManagementClient(credentials) { SubscriptionId = subscriptionId };
            LinkedServiceResource storageLinkedService = new LinkedServiceResource(new AzureStorageLinkedService{
                         ConnectionString = new SecureString("DefaultEndpointsProtocol=https;AccountName=" + storageAccount + ";AccountKey=" + storageKey)});
           var result =client.LinkedServices.CreateOrUpdateWithHttpMessagesAsync(resourceGroup, factoryName, storageLinkedServiceName, storageLinkedService).Result;
