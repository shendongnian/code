    public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, 5000, listenOptions =>
                    {
                        listenOptions.UseHttps("localhost.pfx", "yourPassword");
                    });
                })
                .UseUrls("https://localhost:5000")
                .Build();
