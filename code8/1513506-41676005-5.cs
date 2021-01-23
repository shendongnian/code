    public class Startup 
    {
        private ILogger _logger;
        public void Configure(IApplicationBuilder app, IApplicationLifetime applicationLifetime, ILoggerFactory loggerFactory) 
        {
            applicationLifetime.ApplicationStopping.Register(OnShutdown);
            ... 
            // add logger providers
            // loggerFactory.AddConsole()
            ...
            _logger = loggerFactory.CreateLogger("StartupLogger");
        }
    
        private void OnShutdown()
        {
             // use _logger here;
        }
    }
