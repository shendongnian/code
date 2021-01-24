    public class ServiceResolver{
     private static WindsorContainer container;
     private static IServiceProvider serviceProvider;
     public ServiceResolver(IServiceCollection services) {
        container = new WindsorContainer();
        //Register your components in container
        //then
        serviceProvider= WindsorRegistrationHelper.CreateServiceProvider(container,serviceCollection);
     }
     public object GetService(Type serviceType) {
        return container.Resolve(serviceType);
     }
     public IServiceProvider GetServiceProvider()
        {
            return serviceProvider;
        }
    }
    public IServiceProvider ConfigureServices(IServiceCollection services) {
        services.AddMvc();
        // Add other framework services
    
        // Add custom provider
        var container = new ServiceResolver(services).GetServiceProvider();
        return container;
    }
