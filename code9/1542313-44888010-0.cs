    /// <summary>
    /// Resolves dependencies against the current DI container.
    /// </summary>
    public class UnityDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer container;
        // NB Not likely to be be big but will be frequent so use HashSet as O(1) lookup cost - see https://stackoverflow.com/questions/18651940/performance-benchmarking-of-contains-exists-and-any
        private readonly HashSet<Type> excludedTypes;
        /// <summary>
        /// Initializes a new instance of the <see cref="UnityDependencyResolver"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public UnityDependencyResolver(IUnityContainer container)
        {
            this.container = container;
            excludedTypes = new HashSet<Type>();
            StandardExclusions();
        }
        /// <summary>
        /// Resolves an instance of the default requested type from the container.
        /// </summary>
        /// <param name="serviceType">The <see cref="Type"/> of the object to get from the container.</param>
        /// <returns>The requested object.</returns>
        public object GetService(Type serviceType)
        {
            if (typeof(IController).IsAssignableFrom(serviceType))
            {
                return container.Resolve(serviceType);
            }
            try
            {
                return excludedTypes.Contains(serviceType) ? null : container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }
        /// <summary>
        /// Resolves multiply registered services.
        /// </summary>
        /// <param name="serviceType">The type of the requested services.</param>
        /// <returns>The requested services.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.ResolveAll(serviceType);
        }
        public void Exclude<T>()
        {
            Exclude(typeof(T));
        }
        public void Exclude(Type type)
        {
            excludedTypes.Add(type);
        }
        public void Include<T>()
        {
            Include(typeof(T));
        }
        public void Include(Type type)
        {
            excludedTypes.Remove(type);
        }
        private void StandardExclusions()
        {
            Exclude<System.Web.Mvc.IControllerFactory>();
            Exclude<System.Web.Mvc.IControllerActivator>();
            Exclude<System.Web.Mvc.ITempDataProviderFactory>();
            Exclude<System.Web.Mvc.ITempDataProvider>();
            Exclude<System.Web.Mvc.Async.IAsyncActionInvokerFactory>();
            Exclude<System.Web.Mvc.IActionInvokerFactory>();
            Exclude<System.Web.Mvc.Async.IAsyncActionInvoker>();
            Exclude<System.Web.Mvc.IActionInvoker>();
            Exclude<System.Web.Mvc.IViewPageActivator>();
            Exclude<System.Web.Mvc.ModelMetadataProvider>();
        }
    }
