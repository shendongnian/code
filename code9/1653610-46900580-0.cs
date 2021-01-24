    public class SomeController
    {
        private readonly StorageProviderOptions _options;
        public SomeController(IOptions<StorageProviderOptions> options)
        {
            _options = options.Value;
        }
    }
