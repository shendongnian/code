    [TestFixture]
    public class SomeServiceTests
    {
  
        private IOptions<SomeServiceConfiguration> _config;
        private SomeService _service;
        [OneTimeSetUp]
        public void GlobalPrepare()
        {
             var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();
            _config = Options.Create(configuration.GetSection("someService").Get<SomeServiceConfiguration>());
        }
        [SetUp]
        public void PerTestPrepare()
        {
            _service = new SomeService(_config);
        }
    }
