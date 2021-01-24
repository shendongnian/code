    static void Main(string[] args)
    {
        var graphClient = new GraphServiceClient(
                    "https://graph.microsoft.com/v1.0",
                    new DelegateAuthenticationProvider(
                        async (requestMessage) =>
                        {
                            var token = await GetTokenForUserAsync();
                            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
                        }));
        var user = graphClient.Me.Request().GetAsync().Result;
        Console.WriteLine(JsonConvert.SerializeObject(user));
        Console.WriteLine("press any key to exit...");
        Console.ReadLine();
    }
