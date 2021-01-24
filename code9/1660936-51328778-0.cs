    public class Startup
    {
        readonly ILoggerFactory loggerFactory;
        public Startup(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Use it here
            loggerFactory.CreateLogger<..>();
        }
    }
