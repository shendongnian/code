      public class ApiTestServer : TestServer
      {
        public ApiTestServer() : base(WebHostBuilder())
        { }
    
        private static IWebHostBuilder WebHostBuilder() =>
          WebHost.CreateDefaultBuilder()
            .UseStartup<Startup>()
            .UseEnvironment("Local")
            .UseKestrel(options =>
            {
              options.Listen(IPAddress.Any, 5001);
            });
      }
