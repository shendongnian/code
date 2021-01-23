    public sealed class ProxyLogger<T> : ILogger
    {
        private readonly Container container;
        public ProxyLogger(Container container) {
            this.container = container;
        }
        // Implement ILogger method(s)
        public void Log(string message) => Logger.Log(message);
        
        private ILogger Logger => Lifestyle.Scoped.GetCurrentScope(container) == null
            ? container.GetInstance<NLogger<T>>()
            : container.GetInstance<NContextLogger<T>>();
    }
