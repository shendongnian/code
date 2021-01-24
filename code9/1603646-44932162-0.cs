    internal class ServiceLocator
    {
        private static IWindsorContainer _container;
        internal static void Initialize(IWindsorContainer container)
        {
            _container = container;
        }
        internal static TService Resolve<TService>(string key = null)
        {
            if (_container == null)
            {
                throw new InvalidOperationException(
                    "ServiceLocator must be initialized with a container by calling Initialize(container).");
            }
            try
            {
                return string.IsNullOrEmpty(key)
                    ? _container.Resolve<TService>()
                    : _container.Resolve<TService>(key);
            }
            catch (ComponentNotFoundException ex)
            {
                throw new InvalidOperationException(string.Format("No component for {0} has been registered.", typeof(TService).FullName), ex);
            }
        }
        internal static void Release(object resolved)
        {
            _container.Release(resolved);
        }
    }
    public class ResolvedService<TService> : IDisposable
    {
        private bool _disposed;
        private readonly TService _resolvedInstance;
        public TService Service
        {
            get { return _resolvedInstance; }
        }
        public ResolvedService(string key = null)
        {
            _resolvedInstance = ServiceLocator.Resolve<TService>(key);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~ResolvedService()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            ServiceLocator.Release(_resolvedInstance);
            _disposed = true;
        }
    }
