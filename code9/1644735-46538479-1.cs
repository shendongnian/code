    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Rest;
    using System.Threading;
    using Microsoft.Rest.Azure.Authentication;
    
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Azure.Management.DataLake.Analytics;
    using Microsoft.Azure.Management.DataLake.Store;
    using Microsoft.Azure.Graph.RBAC;
    using Microsoft.Azure.Management.DataLake.Analytics.Models;
    using System.Security.Cryptography.X509Certificates;
    
    namespace WebJob1
    {
        public class Functions
        {
            // This function will get triggered/executed when a new message is written 
            // on an Azure Queue called queue.
            public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log)
            {
                string adlaAccountName = "adlaAccountName";
                string subscriptionId = "yoursubscriptionid";
    
                string domain = "tenantid";
                var armTokenAudience = new Uri(@"https://management.core.windows.net/");
                var adlTokenAudience = new Uri(@"https://datalake.azure.net/");
                var aadTokenAudience = new Uri(@"https://graph.windows.net/");
    
                // ----------------------------------------
                // Perform authentication to get credentials
                // ----------------------------------------
    
    
                // NON - INTERACTIVE WITH SECRET KEY
                string clientId = "clientId";
                string secretKey = "clientsecretKey";
                var armCreds = GetCredsServicePrincipalSecretKey(domain, armTokenAudience, clientId, secretKey);
                var adlCreds = GetCredsServicePrincipalSecretKey(domain, adlTokenAudience, clientId, secretKey);
                var aadCreds = GetCredsServicePrincipalSecretKey(domain, aadTokenAudience, clientId, secretKey);
    
                // INTERACTIVE WITH CACHE
                //var tokenCache = new TokenCache();
                //tokenCache.BeforeAccess = BeforeTokenCacheAccess;
                //tokenCache.AfterAccess = AfterTokenCacheAccess;
                //var armCreds = GetCredsInteractivePopup(domain, armTokenAudience, tokenCache, PromptBehavior.Auto);
                //var adlCreds = GetCredsInteractivePopup(domain, adlTokenAudience, tokenCache, PromptBehavior.Auto);
                //var aadCreds = GetCredsInteractivePopup(domain, aadTokenAudience, tokenCache, PromptBehavior.Auto);
    
                // INTERACTIVE WITHOUT CACHE
                // var armCreds = GetCredsInteractivePopup(domain, armTokenAudience, PromptBehavior.Auto);
                // var adlCreds = GetCredsInteractivePopup(domain, adlTokenAudience, PromptBehavior.Auto);
                // var aadCreds = GetCredsInteractivePopup(domain, aadTokenAudience, PromptBehavior.Auto);
    
    
                // NON-INTERACTIVE WITH CERT
                // string clientId = "<service principal / application client ID>";
                // var certificate = new X509Certificate2(@"<path to (PFX) certificate file>", "<certificate password>");
                // var armCreds = GetCredsServicePrincipalCertificate(domain, armTokenAudience, clientId, certificate);
                // var adlCreds = GetCredsServicePrincipalCertificate(domain, adlTokenAudience, clientId, certificate);
                // var aadCreds = GetCredsServicePrincipalCertificate(domain, aadTokenAudience, clientId, certificate);
    
                // ----------------------------------------
                // Create the REST clients using the credentials
                // ----------------------------------------
    
                var adlaAccountClient = new DataLakeAnalyticsAccountManagementClient(armCreds);
                adlaAccountClient.SubscriptionId = subscriptionId;
    
                var adlsAccountClient = new DataLakeStoreAccountManagementClient(armCreds);
                adlsAccountClient.SubscriptionId = subscriptionId;
    
                var adlaCatalogClient = new DataLakeAnalyticsCatalogManagementClient(adlCreds);
                var adlaJobClient = new DataLakeAnalyticsJobManagementClient(adlCreds);
                var adlsFileSystemClient = new DataLakeStoreFileSystemManagementClient(adlCreds);
    
                var graphClient = new GraphRbacManagementClient(aadCreds);
                graphClient.TenantID = domain;
    
                // ----------------------------------------
                // Perform operations with the REST clients
                // ----------------------------------------
    
                var script = @" your script ";
                var jobId = Guid.NewGuid();
                var properties = new USqlJobProperties(script);
                var parameters = new JobInformation("test1", JobType.USql, properties, priority: 1, degreeOfParallelism: 1, jobId: jobId);
                //Create and submit new job
                var jobInfo = adlaJobClient.Job.Create(adlaAccountName, jobId, parameters);
            }
    
            // The interactive samples reuse Azure PowerShell's client ID
            // For production code you should use your own client ids
            private static string azure_powershell_clientid = "1950a258-227b-4e31-a9cf-717495945fc2";
    
            /*
             *  Interactive: User popup
             *  (no token cache to reuse/save session state)
             */
            private static ServiceClientCredentials GetCredsInteractivePopup(string domain, Uri tokenAudience, PromptBehavior promptBehavior = PromptBehavior.Auto)
            {
                SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
    
                // The client id comes from Azure PowerShell
                // for production code you should use your own client id
    
                var clientSettings = new ActiveDirectoryClientSettings
                {
                    ClientId = azure_powershell_clientid,
                    ClientRedirectUri = new Uri("urn:ietf:wg:oauth:2.0:oob"),
                    PromptBehavior = promptBehavior
                };
    
                var serviceSettings = ActiveDirectoryServiceSettings.Azure;
                serviceSettings.TokenAudience = tokenAudience;
    
                var creds = UserTokenProvider.LoginWithPromptAsync(domain, clientSettings, serviceSettings).GetAwaiter().GetResult();
    
                return creds;
            }
    
            /*
             *  Interactive: User popup
             *  (using a token cache to reuse/save session state)
             */
            private static ServiceClientCredentials GetCredsInteractivePopup(string domain, Uri tokenAudience, TokenCache tokenCache, PromptBehavior promptBehavior = PromptBehavior.Auto)
            {
                SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
    
                var clientSettings = new ActiveDirectoryClientSettings
                {
                    ClientId = azure_powershell_clientid,
                    ClientRedirectUri = new Uri("urn:ietf:wg:oauth:2.0:oob"),
                    PromptBehavior = promptBehavior
                };
    
                var serviceSettings = ActiveDirectoryServiceSettings.Azure;
                serviceSettings.TokenAudience = tokenAudience;
    
                var creds = UserTokenProvider.LoginWithPromptAsync(domain, clientSettings, serviceSettings, tokenCache).GetAwaiter().GetResult();
    
                return creds;
            }
     
     
    
            /*
             *  Interactive: Device code login
             *  NOT YET SUPPORTED by Azure's .NET SDK authentication library
             */
            private static ServiceClientCredentials GetCredsDeviceCode()
            {
                throw new NotImplementedException("Azure SDK's .NET authentication library doesn't support device code login yet.");
            }
    
            /*
             *  Non-interactive: Service principal / application using a secret key
             *  Setup: https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-authenticate-service-principal#create-service-principal-with-password
             */
            private static ServiceClientCredentials GetCredsServicePrincipalSecretKey(string domain, Uri tokenAudience, string clientId, string secretKey)
            {
                SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
    
                var serviceSettings = ActiveDirectoryServiceSettings.Azure;
                serviceSettings.TokenAudience = tokenAudience;
    
                var creds = ApplicationTokenProvider.LoginSilentAsync(domain, clientId, secretKey, serviceSettings).GetAwaiter().GetResult();
    
                return creds;
            }
    
            /*
             *  Non-interactive: Service principal / application using a certificate
             *  Setup: https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-authenticate-service-principal#create-service-principal-with-self-signed-certificate
             */
            private static ServiceClientCredentials GetCredsServicePrincipalCertificate(string domain, Uri tokenAudience, string clientId, X509Certificate2 certificate)
            {
                SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
    
                var clientAssertionCertificate = new ClientAssertionCertificate(clientId, certificate);
                var serviceSettings = ActiveDirectoryServiceSettings.Azure;
                serviceSettings.TokenAudience = tokenAudience;
    
                var creds = ApplicationTokenProvider.LoginSilentWithCertificateAsync(domain, clientAssertionCertificate, serviceSettings).GetAwaiter().GetResult();
    
                return creds;
            }
        }
    }
