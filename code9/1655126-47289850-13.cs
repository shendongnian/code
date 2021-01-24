    namespace GraphTestConsole
    {
        using Microsoft.Graph;
        using Microsoft.IdentityModel.Clients.ActiveDirectory;
        using Nito.AsyncEx;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Net.Http.Headers;
        using System.Security;
        using System.Threading.Tasks;
    
        public class Program
        {
            private const string Resource = "https://graph.microsoft.com";
    
            private const string AppClientId = "YOUR_CLIENT_ID";
    
            private static readonly SecureString AppClientSecretSecure = ToSecureString("YOUR_CLIENT_SECRET");
    
            private const string Tenant = "YOUR_TENANT.onmicrosoft.com";
    
            private static IGraphServiceClient _graphClient;
    
            private static string _token;
    
            private static DateTimeOffset _tokenExpiresOn = DateTime.Now;
    
            private static readonly AsyncLock _mutex = new AsyncLock();
    
            public static void Main(string[] args)
            {
                AsyncContext.Run(() => AsyncMain(AppClientId, AppClientSecretSecure, Tenant));
            }
    
            private static async Task AsyncMain(string appId, SecureString appSecretSecure, string tenant)
            {
                try
                {
                    var upn = "YOUR_USER_UPN";
                    _graphClient = GetGraphClient(appId, appSecretSecure, tenant);
                    var user = await _graphClient.Users[upn].Request().Select("id").GetAsync();
                }
                catch (Exception ex)
                {
                    // Handle the exception...
                    Console.WriteLine(DateTime.Now.ToString());
                    Console.WriteLine(ex);
                }
            }
    
            private static bool IsTokenInvalid => string.IsNullOrEmpty(_token) || (_tokenExpiresOn - DateTime.Now).TotalSeconds <= 0;
    
            private static GraphServiceClient GetGraphClient(string appClientId, SecureString appSecretSecure, string tenant)
            {
                var delegateAuthProvider = new DelegateAuthenticationProvider(async (requestMessage) =>
                {
                    using (await _mutex.LockAsync())
                    {
                        if (IsTokenInvalid)
                        {
                            var authContext = new AuthenticationContext($"https://login.microsoftonline.com/{tenant}/oauth2/token");
                            var result = await authContext.AcquireTokenAsync(Resource, new ClientCredential(appClientId, new SecureClientSecret(appSecretSecure)));
    
                            _token = result.AccessToken;
                            _tokenExpiresOn = result.ExpiresOn;
                        }
    
                        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", _token);
                    }
                });
    
                return new GraphServiceClient(delegateAuthProvider);
            }
    
            private static SecureString ToSecureString(IEnumerable<char> value)
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
    
                var secured = new SecureString();
                var charArray = value.ToArray();
    
                for (int i = 0; i < charArray.Length; i++)
                {
                    secured.AppendChar(charArray[i]);
                }
    
                secured.MakeReadOnly();
                return secured;
            }
        }
    }
