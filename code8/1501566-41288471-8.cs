    public class Startup
    {
        ILogger _logger;
        IFormatter _formatter;
        public Startup(ILoggerFactory loggerFactory, IFormatter formatter)
        {
            _logger = loggerFactory.CreateLogger<Startup>();
            _formatter = formatter;
        }
     
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogDebug($"Total Services Initially: {services.Count}");
     
            // register services
            //services.AddSingleton<IFoo, Foo>();
        }
     
        public void Configure(IApplicationBuilder app, IFormatter formatter)
        {
            // note: can request IFormatter here as well as via constructor
            _logger.LogDebug("Configure() started...");
            app.Run(async (context) => await context.Response.WriteAsync(_formatter.Format("Hi!")));
            _logger.LogDebug("Configure() complete.");
        }
    }
