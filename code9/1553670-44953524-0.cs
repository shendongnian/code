    public static void Main(string[] args)
    {
        string environmentName;
    #if DEBUG
        environmentName = "Development";
    #elif STAGING
        environmentName = "Staging";
    #elif RELEASE
        environmentName = "Production";
    #endif
        var host = new WebHostBuilder()
            .UseKestrel()
            .UseEnvironment(environmentName)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .UseApplicationInsights()
            .Build();
        host.Run();
    }
