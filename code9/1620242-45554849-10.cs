    public static class BootStrapper {
    
        private static IUnityContainer BuildUnityContainer() {
        	var container = new UnityContainer();
    
            //Register types with Unity
        	container.RegisterType<IProductsCSV , ProductsCSV>();
        	container.RegisterType<IProductsCsvReader, DefaultProductsCsvReader>();
        
        	return container;
        }
    
        public static void Initialise() {
            //create container
        	var container = BuildUnityContainer();
            //grab the current resolver
        	IDependencyResolver resolver = DependencyResolver.Current;
            //create the new resolver that will be used to replace the current one
        	IDependencyResolver newResolver = new UnityDependencyResolver(container, resolver);
            //assign the new resolver.
        	DependencyResolver.SetResolver(newResolver);
        }
    }
    
    public class UnityDependencyResolver : IDependencyResolver {
        private IUnityContainer container; 
        private IDependencyResolver resolver;
        public UnityDependencyResolver(IUnityContainer container, IDependencyResolver resolver) {
            this.container = container;
            this.resolver = resolver;
        }
        public object GetService(Type serviceType) {
            try {
                return this.container.Resolve(serviceType);
            } catch {
                return this.resolver.GetService(serviceType);
            }
        }
        public IEnumerable<object> GetServices(Type serviceType) {
            try {
                return this.container.ResolveAll(serviceType);
            } catch {
                return this.resolver.GetServices(serviceType);
            }
        }
     }
    
