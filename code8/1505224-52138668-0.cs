    public static async Task Main(string[] args)
    {
        var builder = new HostBuilder()
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", true);
                if (args != null) config.AddCommandLine(args);
            })
            .ConfigureServices((hostingContext, services) =>
            {
                services.AddHostedService<MyHostedService>();
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration);
                logging.AddConsole();
            });
        await builder.RunConsoleAsync();
    }
