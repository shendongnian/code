    public static IWebHost BuildWebHost(string[] args)
    {
            var config = new ConfigurationBuilder().AddCommandLine(args).Build();
            return WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseStartup<Startup>()
                .Build();
    }
