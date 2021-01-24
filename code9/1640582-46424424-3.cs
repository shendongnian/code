     public class Program
        {
            public static void Main(string[] args)
            {
                var host = new WebHostBuilder()
                    .UseKestrel(config => config.AddServerHeader = false)
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        var env = hostingContext.HostingEnvironment;
                        config.AddJsonFile("config\\appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"config\\appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                        config.AddEnvironmentVariables();
                    })
                    .ConfigureLogging((hostingContext, logging) =>
                    {
                        // Add custom logger
                        logging.AddAppLogger();
    
                        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                        logging.AddConsole();
                        if (hostingContext.HostingEnvironment.IsDevelopment())
                        {
                            logging.AddDebug();
                        }
    
                    })
                    .UseStartup<Startup>()
    
                    .Build();
    
    
                host.Run();
            }
