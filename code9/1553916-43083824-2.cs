      public static async Task  CreateDirectory()
        {
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
            var domain = "microsoft.onmicrosoft.com";
            var webApp_clientId = "client id";
            var clientSecret = "client secret";
            var clientCredential = new ClientCredential(webApp_clientId, clientSecret);
            var creds = ApplicationTokenProvider.LoginSilentAsync(domain, clientCredential).Result;
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
            _adlsClient = new DataLakeStoreAccountManagementClient(creds) { SubscriptionId = "_subId" };
            _adlsFileSystemClient = new DataLakeStoreFileSystemManagementClient(creds);
            await _adlsFileSystemClient.FileSystem.MkdirsAsync("_adlsAccountName", "tempdir");
        }
        static void Main(string[] args)
        {
          CreateDirectory().Wait();
        }
