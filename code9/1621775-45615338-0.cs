      class Program
    {
        static void Main(string[] args)
        {
      
            Create().Wait();
            Console.ReadLine();
        }
        private static async Task Create()
        {
            var graph = new GraphServiceClient(new AzureAuthenticationProvider());
            try
            {
                var users = await graph.Users.Request().GetAsync();
                int requestNumber = 1;
                while (users.Count > 0)
                {
                    Console.WriteLine("Request number: {0}", requestNumber++);
                    foreach (var u in users)
                    {
                        Console.WriteLine("User: {0} ({1})", u.DisplayName,
                            u.UserPrincipalName);
                    }
                    if (users.NextPageRequest != null)
                    {
                        users = await users.NextPageRequest.GetAsync();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (ServiceException x)
            {
                Console.WriteLine("Exception occured: {0}", x.Error);
            }
        }
    }
    internal class AppModeConstants
    {
        public const string ClientId = "YOUR_CLIENT_ID_HERE";
        public const string ClientSecret = "YOUR_SECRET_HERE";
        public const string TenantName = "YOUR_TENANT_NAME_HERE";  //somedomain.com
        public const string TenantId = "YOUR_TENANT_ID_HERE";
        public const string AuthString = GlobalConstants.AuthString + TenantName;
    }
    internal class GlobalConstants
    {
        public const string AuthString = "https://login.microsoftonline.com/";
        public const string ResourceUrl = "https://graph.microsoft.com";
        public const string GraphServiceObjectId = "00000002-0000-0000-c000-000000000000";
    }
    public class AzureAuthenticationProvider : IAuthenticationProvider
    {
        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {         
            AuthenticationContext authContext = new AuthenticationContext(AppModeConstants.AuthString,false);
            ClientCredential creds = new ClientCredential(AppModeConstants.ClientId, AppModeConstants.ClientSecret);
            AuthenticationResult authResult = await authContext.AcquireTokenAsync(GlobalConstants.ResourceUrl,creds);
            request.Headers.Add("Authorization", "Bearer " + authResult.AccessToken);
        }
    }  
