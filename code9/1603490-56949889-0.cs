        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                .ConfigureLogging(logging =>
                {                
                    // Optional: Apply filters to configure LogLevel Trace or above is sent to
                    // ApplicationInsights for all categories.
                    logging.AddFilter<ApplicationInsightsLoggerProvider>("", LogLevel.Trace);
    			
                    // Additional filtering For category starting in "Microsoft",
                    // only Warning or above will be sent to Application Insights.
                    logging.AddFilter<ApplicationInsightsLoggerProvider>("Microsoft", LogLevel.Warning);
    
                })
                .UseStartup<Startup>();
    }
