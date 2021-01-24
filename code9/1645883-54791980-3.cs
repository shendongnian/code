    public static void RegisterComponents()
    {
    	var container = new UnityContainer();
    	
    	container.RegisterType<PrimaryContext>(new InjectionConstructor());
    	container.RegisterType<LocationService>();
    	
    	DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    }
