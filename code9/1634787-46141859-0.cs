    loggerFactory
        .WithFilter(
            new FilterLoggerSettings
            {
                {"AssetTrader", LogLevel.Debug},
                {"Microsoft", LogLevel.Warning},
                {"System", LogLevel.Warning},
            })
        .AddConsole();
