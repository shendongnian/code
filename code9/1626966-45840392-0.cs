        // using Serilog.Extensions.Logging;
        
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(logging => 
                {
                    logging.AddFilter<SerilogLoggerProvider>("Microsoft", LogLevel.Warning);
                }
                .UseStartup<Startup>()
                .Build();
