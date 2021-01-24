    // Part of the Composition Root
    private class ContextConfiguration
    {
        public readonly string Url;
        public readonly string Key;
        public ContextConfiguration(string url, string key) { ... }
    }
    private class CompositionRootContext<T> : Context<T>
    {
        public Context(ContextConfiguration config) : base(config.Url, config.Key)
        {
        }
        ...
    }
    // Configuration
    container.RegisterSingleton(new ContextConfiguration(...));
    container.Register(typeof(IContext<>), typeof(CompositionRootContext<>));
