    public class UnityResolver : IDependencyResolver
    {
        public IUnityContainer _container;
        public UnityResolver()
        {
            _container = new UnityContainer();
            RegisterTypes(_container);
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }
        public object GetService(Type serviceType)
        {
            if(_container.IsRegistered(serviceType))
            {
                return _container.Resolve(serviceType);
            }
            return null;
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }
        public void Dispose()
        {
        }
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            // TODO: Register your types here
            container.RegisterType<ProductController>();
            container.RegisterType<IProductServices, ProductServices>();
            //Component initialization via MEF
            //ComponentLoader.LoadContainer(container, ".\\bin", "WebApi.dll");
            //ComponentLoader.LoadContainer(container, ".\\bin", "BusinessServices.dll");
        }
    }
