    class Program
    {
        static string authority = "https://login.microsoftonline.com/adfei.onmicrosoft.com";
        static string resrouce = "https://graph.microsoft.com";
        static string clientId = "";
        static string secret = "";
        static ClientCredential credential = new ClientCredential(clientId, secret);
        static AuthenticationContext authContext = new AuthenticationContext(authority);
        static void Main(string[] args)
        {
            while (true)
            {
                var client = new GraphServiceClient(new DelegateAuthenticationProvider(request =>
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("bearer", GetAccessToken());
                    return Task.FromResult(0);
                }));
                var users = client.Users.Request().GetAsync().Result.CurrentPage;
                foreach (var user in users)
                {
                    Console.WriteLine(user.DisplayName);
                }          
                Thread.Sleep(1000 * 60 * 5);
            }
            Console.Read();
        }
  
        static string GetAccessToken()
        {
            try
            {
                var token = authContext.AcquireTokenAsync(resrouce, credential).Result.AccessToken;             
                return token;
            }
            catch (Exception ex)
            {
                authContext = new AuthenticationContext(authority);
                return GetAccessToken();
            }
        }
