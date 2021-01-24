    using(var server = WebHost.CreateDefaultBuilder(new List<string>().ToArray())
        .UseEnvironment("Test")
        .UseStartup<Startup>()
        .UseKestrel(options =>
        {
            options.Listen(IPAddress.Loopback, 5000);
        })
        .Build())
        {
            server.Start();
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000")
            }
            var resp = client.GetAsync("test/testme").Result;
        }
