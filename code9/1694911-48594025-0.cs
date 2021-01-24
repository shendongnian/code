    Log.Logger = new LoggerConfiguration()
	    .Enrich.FromLogContext()
	    .MinimumLevel.Information()
	    .WriteTo.Console(outputTemplate:
		"[{Timestamp:HH:mm:ss} {Level:u3}] {UserId} {Event} - {Message}{NewLine}{Exception}")
	    .CreateLogger();
    using (LogContext.PushProperty("UserId", "123"))
    using (LogContext.PushProperty("Event", "Test Event"))
    {
    	Log.Information("Here is my message about order {OrderNumber}", 567);
    	Log.Information("Here is my message about product {ProductId}", "SomeProduct");
    }
