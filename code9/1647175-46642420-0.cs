        //if you want to use ApplicationInsights just change the write to's method as Serilog.Sinks.ApplicationInsights links shows
        Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
           .Enrich.FromLogContext()
           .WriteTo.RollingFile("log-{Date}.txt")
           .CreateLogger();
        Log.Information("This will be written to the rolling file set");
