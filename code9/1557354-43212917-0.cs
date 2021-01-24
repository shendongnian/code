	public static void Register(HttpConfiguration config)
	{	
		UnityContainer container = new UnityContainer();
		// This contains our actual container registrations.	
		UnityRegistrer.Register(container); 
		// IoC for WebAPI
		config.DependencyResolver = new UnityResolver(container);
		// IoC for WebForms
		HttpContext.Current.Application.SetContainer(container);
		// IoC for MVC5
		DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		
		// Configure other stuff like routes, tracing, error handling, authorization, etc.
	}
