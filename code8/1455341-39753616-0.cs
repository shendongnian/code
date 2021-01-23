    public interface ITester {
        void Initialize(TestOptions options);
    }
    
    public class Tester : ITester {
        public void Initialize(TestOptions options) {
            //do something with options.
        }
    }
    public class TestConfigurator : IConfigureOptions<TestOptions> {
        private ITester _tester;
    
        public TestConfigurator(ITester tester) {
            _tester = tester;
        }
    
        public void Configure(TestOptions options) {
            _tester.Initialize(options);
        }
    }
