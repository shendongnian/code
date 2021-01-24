    public void ConfigureServices(IServiceCollection services)
            {
                // Add Logging logics
                services.AddSingleton(provider =>
                    new Func<string, LogLevel, bool>((n, l) => l >= LogLevel.Error || n.EndsWith("AppLogger", StringComparison.OrdinalIgnoreCase)));
            }
