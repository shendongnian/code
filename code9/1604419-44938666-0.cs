    public class MyClass
    {
        private ILogger _logger;
    
        public MyClass(ILogger logger)
        {
            _logger = logger;
        }
    
        public void DoSomething()
        {
            logger.Information("Something happened");
        }
    }
