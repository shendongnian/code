    public static IWebHost BuildWebHost(string[] args)
    {
        // Load configuration and append command line args
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            .AddJsonFile("configuration.json")
            .AddCommandLine(args)
            .Build();
        // pass config to Startup instance
        var startup = new Startup(config);
        // Instead of using UseStartup<Startup>()
        // Register startup to services
        return new WebHostBuilder()
            .UseKestrel()
            .UseSetting("applicationName", "Your.Assembly.Name")
            .UseConfiguration(config)
            .ConfigureServices(services => services.AddSingleton<IStartup>(startup))
            .Build();
    }
