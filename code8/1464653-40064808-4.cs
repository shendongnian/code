    public static void Main(string[] args)
    {
        var host = GetHostBuilder()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .Build();
    
        host.Run();
    }
    //move your common configurations here
    public static IWebHostBuilder GetHostBuilder()
    {
        return new WebHostBuilder()
            .UseKestrel()
            .UseStartup<Startup>();
    }
