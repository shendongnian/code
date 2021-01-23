    class Program
    {
        static void Main(string[] args)
        {
            AvocadoDemo();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
        static async Task AvocadoDemo()
        {
            string thisConsoleAppClientId = "c588cf8d-8651-4b37-8d10-49237cf92f8e";
            Uri thisConsoleAppUri = new Uri("http://bruceConsoleForAvocado");
            string avocadoResourceUri = "https://microsoft.onmicrosoft.com/Avocado";
            // Get the access token for Avocado. This will pop up the login dialog and consent page for the first time.
            // Then the token will be cached in the FileCache, and AcquireToken will renew the token automatically in the subsequent run.
            AuthenticationContext authCtx = new AuthenticationContext("https://login.windows.net/microsoft.onmicrosoft.com", new FileCache());
            var authResult = await authCtx.AcquireTokenAsync(avocadoResourceUri, thisConsoleAppClientId, thisConsoleAppUri, new PlatformParameters(PromptBehavior.Auto));
            if (!string.IsNullOrEmpty(authResult.AccessToken))
                Console.WriteLine("accessToken: " + authResult.AccessToken);
            // call Avocado API
            var baseAddress = new Uri("https://avocado");
            var cookieContainer = new CookieContainer();
            // POSTing a new execution will invoke a redirect, so for example purposes we are disabling it here.
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer, AllowAutoRedirect = false })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                // Need to set this cookie for avocado api to work.
                cookieContainer.Add(baseAddress, new Cookie("deep_link", "-1"));
                // add your access token in the header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
                // Here's a GET example
                var avoResultGet = client.GetAsync("/schedules/7215.json").Result;
                var strGet = avoResultGet.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Avocado API returns: " + strGet);
            }
        }
    }
