    public class AspNetCoreLifecycle : ILifecycle {
        private readonly object mapLock = new object();
        public string Description => "Asp Net Core Lifecycle object";
        private readonly Container container;
        private Dictionary<HttpContext, IObjectCache> contextMap = new Dictionary<HttpContext, IObjectCache>();
        public AspNetCoreLifecycle(Container cont) {
            this.container = cont;
            
        }
        public void EjectAll(ILifecycleContext context) {
            lock (mapLock) {
                foreach (var kvp in contextMap) {
                    kvp.Value.DisposeAndClear();
                }
                contextMap = new Dictionary<HttpContext, IObjectCache>();
            }
        }
        public IObjectCache FindCache(ILifecycleContext context) {
            var accessor = container.GetInstance<IHttpContextAccessor>();
            lock (mapLock) {
                if (!contextMap.ContainsKey(accessor.HttpContext)) {
                    contextMap.Add(accessor.HttpContext, new LifecycleObjectCache());
                }
                return contextMap[accessor.HttpContext];
            }
        }
    }
