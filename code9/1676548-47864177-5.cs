    public class MyExampleService
    {
        private readonly MyStateOptions _options;
        public MyExampleService(IOptions<MyStateOptions> options)
        {
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }
    }
