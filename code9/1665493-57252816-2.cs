        using NLog;
    using  NLog.Extensions.Logging;     
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                    WebHost.CreateDefaultBuilder(args)
                    .UseKestrel(options =>
                    {
                        // options.Listen(IPAddress.Loopback, 5000); //HTTP port
                    })
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseIISIntegration()
                        .ConfigureLogging((hostingContext, logging) =>
                                    {
                                        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                                        logging.AddConsole();
                                        logging.AddDebug();
                                        logging.AddEventSourceLogger();
                                        // Enable NLog as one of the Logging Provider
                                        logging.AddNLog();
                                    })
                        .UseStartup<Startup>();
