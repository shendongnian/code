        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
        public static IWebHost BuildWebHost(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddCommandLine(args).Build();
            return WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(configuration)
                .UseStartup<Startup>()
                .Build();
        }
