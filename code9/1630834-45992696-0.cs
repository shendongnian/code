        static void Main(string[] args)
        {
            var subscriptionId = "your subscriptionId";
            var clientId = "your client id";
            var tenantId = "your tenantid";
            var secretKey = "secretKey";
            StorageManagementClient StorageManagement = new StorageManagementClient(new Microsoft.Azure.TokenCloudCredentials(subscriptionId, GetAccessToken(tenantId, clientId, secretKey)));
           
              var re=   StorageManagement.StorageAccounts.CreateAsync("groupname", "sotrage name",new Microsoft.Azure.Management.Storage.Models.StorageAccountCreateParameters() {
                  Location = LocationNames.NorthEurope,
                 AccountType = Microsoft.Azure.Management.Storage.Models.AccountType.PremiumLRS
              },new CancellationToken() { }).Result;
                Console.ReadKey();
            
        }
        
          static string GetAccessToken(string tenantId, string clientId, string secretKey)
        {
            var authenticationContext = new AuthenticationContext($"https://login.windows.net/{tenantId}");
            var credential = new ClientCredential(clientId, secretKey);
            var result = authenticationContext.AcquireTokenAsync("https://management.core.windows.net/",
                credential);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain the JWT token");
            }
            var token = result.Result.AccessToken;
            return token;
        }
