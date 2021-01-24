    public static void Main()
    {
        var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddJsonFile("hosting.json", optional: false)
                    .AddEnvironmentVariables();
            })
            .ConfigureLogging((webhostContext, builder) => {
                builder.AddConfiguration(webhostContext.Configuration.GetSection("Logging"))
                .AddConsole()
                .AddDebug();
            })
            .UseIISIntegration()
            .UseStartup<Startup>()
            .UseApplicationInsights()
            .Build();
        host.Run();
    }
