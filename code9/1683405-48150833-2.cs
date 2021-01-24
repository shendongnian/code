    public class IntegrationTestsStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<TokenClient>(() =>
            {
                var handler = TestUtilities.GetTestServer().CreateHandler();
                var client = new TokenClient(TokenEndpoint, clientId, clientSecret, innerHttpMessageHandler: handler);
                return client;
            };
            services.AddTransient<UserAccessToken>();
        }
    }
