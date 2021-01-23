            private static void Initialize()
    		{
    			Initializer.Initialize(registration => registration.AsSingleton());
    			var container = React.AssemblyRegistration.Container;
    			// Register some components that are normally provided by the integration library
    			// (eg. React.AspNet or React.Web.Mvc6)
    			container.Register<ICache, NullCache>();
    			container.Register<IFileSystem, SimpleFileSystem>();
    		}
