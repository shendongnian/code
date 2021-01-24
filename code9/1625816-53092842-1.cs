    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.Sink(jsonSink)
                    .Enrich.WithExceptionDetails()
                    .CreateLogger();
            Log.Logger = logger;
        }
    }
