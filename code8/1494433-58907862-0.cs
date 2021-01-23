        public static void Import()
        {
            KeyVaultClient vaultClient = new KeyVaultClient(GetAccessToken);
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(2048);
            var keyBundle = Task.Run(() => vaultClient.ImportKeyAsync("<YOUR BASE VAULT ID>", "ImportedKey", new KeyBundle(new JsonWebKey(rsaProvider, true)), true)).
               ConfigureAwait(false).GetAwaiter().GetResult();
         }
        public static async Task<string> GetAccessToken(string authority, string resource, string scope)
        {
            string AppId = "<YOUR APP ID GUID>";
            string AppSecret = "<YOUR APP SECRET>";
            var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(AppId, AppSecret);
            AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);
            if (result == null)
                throw new InvalidOperationException("Failed to obtain the JWT token");
            return result.AccessToken;
        }
