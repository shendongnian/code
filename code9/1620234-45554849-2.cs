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
        	IDependencyResolver newResolver = new Factories.UnityDependencyResolver(container, resolver);
            //assign the new resolver.
        	DependencyResolver.SetResolver(newResolver);
        }
    }
