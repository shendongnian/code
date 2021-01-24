    public class TestClass
    {
        private readonly IOptionsSnapshot<AppConfiguration> _options;
        public TestClass(IOptionsSnapshot<AppConfiguration> optionsSnapshot)
        {
            _options = optionsSnapshot;
        }
        public SomeViewModel DoSomething()
        {
            // access the options
            var active = _options.Value.MQTTSettings.Active;
            // it’s fine to actively create *data* objects
            return new SomeViewModel()
            {
                IsActive = active,
            };
        }
    }
