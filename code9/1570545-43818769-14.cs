    public class TestContext_SmokeTests : BaseTest
    {
        public TestContext_SmokeTests(ITestOutputHelper output)
            : base(output)
        {
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            _loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            _loggerFactory.AddProvider(new XUnitLoggerProvider(this));
        }
        private readonly ILoggerFactory _loggerFactory;
    }
    
