    // this is the facade that you will work from, instead of ServiceClient
    public interface IMyServiceClient : IDisposable
    {
        void Query(string query);
    }
    
    // This is your factory, reworked to provide flyweight instances
    // of IMyServiceClient, instead of the real ServiceClient
    public class ServiceClientFactory : IDisposable
    {
        // This is the concrete implementation of IMyServiceClient 
        // that the factory will create and you can pass around; it 
        // provides both the reference count and facade implementation
        // and is nested inside the factory to indicate that consumers 
        // should not alter these (and cannot without reflecting on 
        // non-publics)
        private class CachedServiceClient : IMyServiceClient
        {
            internal ServiceClient _realServiceClient;
            internal int _referenceCount;
       
            #region Facade wrapper methods around real ServiceClient ones
            void IMyServiceClient.Query(string query)
            {
                _realServiceClient.Query(query);
            }
            #endregion
    
            #region IDisposable for the client facade
            private bool _isClientDisposed = false;
    
            protected virtual void Dispose(bool disposing)
            {
                if (!_isClientDisposed)
                {
                    if (Interlocked.Decrement(ref _referenceCount) == 0)
                    {
                        // if there are no more references, we really
                        // dispose the real object
                        using (_realServiceClient) { /*NOOP*/ }
                    }
                    _isClientDisposed = true;
                }
            }
    
            ~CachedServiceClient() { Dispose(false); }
    
            void IDisposable.Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            #endregion
        }
    
        // The object cache; note that it is not static
        private readonly ConcurrentDictionary<string, CachedServiceClient> _cache
            = new ConcurrentDictionary<string, CachedServiceClient>();
    
        // The method which allows consumers to create the client; note
        // that it returns the facade interface, rather than the concrete
        // class, so as to hide the implementation details
        public IMyServiceClient CreateServiceClient(string host)
        {
            var cached = _cache.GetOrAdd(
                host,
                k => new CachedServiceClient()
            );
            if (Interlocked.Increment(ref cached._referenceCount) == 1)
            {
                cached._realServiceClient = new ServiceClient(host);
            }
            return cached;
        }
    
        #region IDisposable for the factory (will forcibly clean up all cached items)
        private bool _isFactoryDisposed = false;
    
        protected virtual void Dispose(bool disposing)
        {
            if (!_isFactoryDisposed)
            {
                Debug.WriteLine($"ServiceClientFactory #{GetHashCode()} disposing cache");
                if (disposing)
                {
                    foreach (var element in _cache)
                    {
                        element.Value._referenceCount = 0;
                        using (element.Value._realServiceClient) { }
                    }
                }
                _cache.Clear();
                _isFactoryDisposed = true;
            }
        }
    
        ~ServiceClientFactory() { Dispose(false); }
    
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
    // This is just an example `ServiceClient` which uses the default
    // implementation of GetHashCode to "prove" that new objects aren't
    // created unnecessarily; note it does not implement `IMyServiceClient`
    public class ServiceClient : IDisposable
    {
        private readonly string _host;
    
        public ServiceClient(string host)
        {
            _host = host;
            Debug.WriteLine($"ServiceClient #{GetHashCode()} was created for {_host}");
        }
    
        public void Query(string query)
        {
            Debug.WriteLine($"ServiceClient #{GetHashCode()} asked '{query}' to {_host}");
        }
    
        public void Dispose()
        {
            Debug.WriteLine($"ServiceClient #{GetHashCode()} for {_host} was disposed");
            GC.SuppressFinalize(this);
        }
    }
