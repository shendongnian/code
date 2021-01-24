    public class ConsoleApp
    {
        private readonly ILogger<ConsoleApp> _logger;
        private readonly IMyConfiguration _config;
        public ConsoleApp(IMyConfiguration configurationRoot, ILogger<ConsoleApp> logger)
        {
            _logger = logger;
            _config = configurationRoot;
        }
        public void Run()
        {
            var test = _config.YourItem;
            _logger.LogCritical(test);
            System.Console.ReadKey();
        }
    }
