    public class Example
    {
        private readonly ILogger<Example> _logger;
        public Example(ITestOutputHelper testOutputHelper)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new XunitLoggerProvider(testOutputHelper));
            _logger = loggerFactory.CreateLogger<Example>();
        }
        [Fact]
        public void Test()
        {
            _logger.LogDebug("Foo bar baz");
        }
    }
