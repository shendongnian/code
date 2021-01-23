    // Entry point for the application.
    public static void Main(string[] args)
    {
        var host = new WebHostBuilder()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseKestrel()
            .UseStartup<Startup>()
            .Build();
    
        host.Run();
    }
