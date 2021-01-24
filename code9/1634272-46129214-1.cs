    public class Foo
    {
        private readonly ApplicationSettings _settings;
        public Foo (IOptions<ApplicationSettings> settings)
        {
            _settings = settings.Value;
        }
    }
