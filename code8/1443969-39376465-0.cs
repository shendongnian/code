    public class AspNetCoreLifecycle : ILifecycle {
        private readonly Container _container;
        private Dictionary<HttpContext, IObjectCache> _contextMap = new Dictionary<HttpContext, IObjectCache>();
        public AspNetCoreLifecycle(Container container) {
            _container = container;
            
        }
        public void EjectAll(ILifecycleContext context) {
            foreach (var kvp in _contextMap)
            {
                kvp.Value.DisposeAndClear();
            }
            _contextMap = new Dictionary<HttpContext, IObjectCache>();
        }
        public IObjectCache FindCache(ILifecycleContext context)
        {
            IHttpContextAccessor accessor = _container.GetInstance<IHttpContextAccessor>();
            
            if (!_contextMap.ContainsKey(accessor.HttpContext)) {
                _contextMap.Add(accessor.HttpContext, new LifecycleObjectCache());
            }
            
            return _contextMap[accessor.HttpContext];
        }
        public string Description => "Asp Net Core Lifecycle object";
    }
