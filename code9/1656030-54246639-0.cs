    using Microsoft.Extensions.Logging;
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .ConfigureLogging(logging =>
        {
            logging.AddAzureWebAppDiagnostics();
        })
        .UseStartup<Startup>();
