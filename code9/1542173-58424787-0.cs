     public async Task<List<KeyValuePair<string, string>>> ListAllSecrets()
        {
            try
            {
                var azureServiceTokenProvider = new AzureServiceTokenProvider();
                var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
                var Secret = keyVaultClient.GetSecretsAsync
                    ("https://xyz.vault.azure.net").GetAwaiter().GetResult();
                var dictionary = new List<KeyValuePair<string, string>>();
                foreach (var item in Secret)
                {
                    var value = keyVaultClient.GetSecretAsync(item.Id).GetAwaiter().GetResult().Value;
                    dictionary.Add(new KeyValuePair<string, string>(item.Identifier.Name, value));
                }
                return dictionary;
            }
            catch (Exception ex)
            {
                return default(List<KeyValuePair<string, string>>);
            }
        }
