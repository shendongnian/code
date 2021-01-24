    using Microsoft.Azure.KeyVault;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Experiments.AzureKeyValut
    {
        internal class AzureKeyValueDemo
        {
            private static async Task Main(string[] args)
            {
                await GetSecretAsync("https://YOURVAULTNAME.vault.azure.net/", "YourSecretKey");
            }
    
            private static async Task<string> GetSecretAsync(string vaultUrl, string vaultKey)
            {
                var client = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetAccessTokenAsync), new HttpClient());
                var secret = await client.GetSecretAsync(vaultUrl, vaultKey);
    
                return secret.Value;
            }
    
            private static async Task<string> GetAccessTokenAsync(string authority, string resource, string scope)
            {
                //DEMO ONLY
                //Storing ApplicationId and Key in code is bad idea :)
                var appCredentials = new ClientCredential("YourApplicationId", "YourApplicationKey");
                var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
    
                var result = await context.AcquireTokenAsync(resource, appCredentials);
    
                return result.AccessToken;
            }
        }
    }
