    public static void Main(string[] args)
    {
        var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .UseApplicationInsights()
            .CaptureStartupErrors(captureStartupErrors: true) // Add this line
            .Build();
    
        host.Run();
    }
