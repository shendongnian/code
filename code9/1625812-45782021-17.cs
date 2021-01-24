    services.AddLogging(builder =>
    {
        builder.AddConfiguration(Configuration.GetSection("Logging"))
            // filter for all providers
            .AddFilter("System", LogLevel.Debug)
            // Only for Debug logger, using the provider type or it's alias
            .AddFilter("Debug", "System", LogLevel.Information)
            // Only for Console logger by provider type
            .AddFilter<DebugLoggerProvider>("System", LogLevel.Error)
            .AddConsole()
            .AddDebug();
    });
