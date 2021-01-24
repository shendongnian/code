        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
        public static IWebHost BuildWebHost(string[] args)
        {
           return  WebHost.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        var env = hostingContext.HostingEnvironment;
                        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                        config.AddEnvironmentVariables();
                    })
                    .ConfigureLogging((hostingContext, logging) =>
                    {
                        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                        logging.AddConsole();
                        logging.AddDebug();
                    })
                    .UseSetting("detailErrors", "true")
                    .UseStartup<Startup>()
                    .UseSetting("DesignTime", "true")
                    .CaptureStartupErrors(true)
                    .Build();
        }
