    public class SomeService
    {
        public SomeService(IOptions<SomeServiceConfiguration> config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(_config));
        }
    }
