    static void Main(string[] args)
    {
        MainAsync(args).GetAwaiter().GetResult();
    }
    static async Task MainAsync(string[] args)
    {
        var graphClient = new GraphServiceClient(
                    "https://graph.microsoft.com/v1.0",
                    new DelegateAuthenticationProvider(
                        async (requestMessage) =>
                        {
                            var token = await GetTokenForUserAsync();
                            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
                        }));
        var user = await graphClient.Me.Request().GetAsync();
        Console.WriteLine(JsonConvert.SerializeObject(user));
    }
