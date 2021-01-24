    internal class CustomWebHostService : WebHostService
    {
        private ILogger _logger;
    
        public CustomWebHostService(IWebHost host) : base(host)
        {
            _logger = host.Services
                .GetRequiredService<ILogger<CustomWebHostService>>();
        }
    
        protected override void OnStarting(string[] args)
        {
            _logger.LogInformation("OnStarting method called.");
            base.OnStarting(args);
        }
    
        protected override void OnStarted()
        {
            _logger.LogInformation("OnStarted method called.");
            base.OnStarted();
        }
    
        protected override void OnStopping()
        {
            _logger.LogInformation("OnStopping method called.");
            base.OnStopping();
        }
    }
