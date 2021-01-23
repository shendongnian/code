    public class Tester
    {
        private TestOptions _options;
        public Tester(IOptions<TestOptions> options)
        {
           _options = options.Value;
        }
    }
    // don't need this anymore
    /* public class TestConfigurator : IConfigureOptions<TestOptions>
    {
        private Tester _tester;
    
        public TestConfigurator(Tester tester)
        {
            _tester = tester;
        }
    
        public void Configure(TestOptions options)
        {
            _tester.Initialize(options);
        }
    }
    */
    public class TestOptions
    {
    }
