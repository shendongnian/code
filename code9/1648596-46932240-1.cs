    class Program
    {
        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();
    
        private static async Task MainAsync()
        {
            // discover endpoints from metadata
            var disco = await DiscoveryClient.GetAsync("http://localhost:65535");
                
            // request token
            var tokenClient = new TokenClient(disco.TokenEndpoint, "teachers_test_client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("teachers_test_planner");
    
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }
    
            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");
    
            // call api
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);
    
            var response = await client.GetAsync("http://localhost:52129/api/values/1");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            Console.ReadKey();
        }
    }
