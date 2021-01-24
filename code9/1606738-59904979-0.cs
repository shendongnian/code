    builder.AddApplicationInsights("ikey");
    builder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>
    			("", LogLevel.Information);
    builder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>
    			("Microsoft", LogLevel.Warning);
