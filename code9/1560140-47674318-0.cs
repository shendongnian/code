    public void Configuration(IAppBuilder app)
            {
                // We will use Dependency Injection for all controllers and other classes, so we'll need a service collection
                var services = new ServiceCollection();
    
                // configure all of the services required for DI
                ConfigureServices(services);
    
                // Configure authentication
                ConfigureAuth(app);
    
                // Create a new resolver from our own default implementation
                var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
    
                // Set the application resolver to our default resolver. This comes from "System.Web.Mvc"
                //Other services may be added elsewhere through time
                DependencyResolver.SetResolver(resolver);
            }
