    /// <summary>
    /// Provides the default dependency resolver for the application - based on IDependencyResolver, which hhas just two methods
    /// </summary>
    public class DefaultDependencyResolver : IDependencyResolver
    {
        /// <summary>
        /// Provides the service that holds the services
        /// </summary>
        protected IServiceProvider serviceProvider;
    
        /// <summary>
        /// Create the service resolver using the service provided (Direct Injection pattern)
        /// </summary>
        /// <param name="serviceProvider"></param>
        public DefaultDependencyResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
    
        /// <summary>
        /// Get a service by type - assume you get the first one encountered
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return this.serviceProvider.GetService(serviceType);
        }
    
        /// <summary>
        /// Get all services of a type
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.serviceProvider.GetServices(serviceType);
        }
    }
