    public class ContextConfiguration
    {
        public readonly string Url;
        public readonly string Key;
        public ContextConfiguration(string url, string key) { ... }
    }
    public class Context<T> : IContext<T>
    {
        public Context(ContextConfiguration config)
        {
        }
        ...
    }
    // Configuration
    container.RegisterSingleton(new ContextConfiguration(...));
    container.Register(typeof(IContext<>), typeof(Context<>));
