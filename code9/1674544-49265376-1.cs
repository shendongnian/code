    public class Startup
    {
      public IContainer ApplicationContainer {get; private set;}
      public IServiceProvider ConfigureServices(IServiceCollection services)
      {
        // Add controllers as services so they'll be resolved.
        services.AddMvc().AddControllersAsServices();
    
        var builder = new ContainerBuilder();
    
        // When you do service population, it will include your controller
        // types automatically.
        builder.Populate(services);
    
        // If you want to set up a controller for, say, property injection
        // you can override the controller registration after populating services.
        builder.RegisterType<MyController>().PropertiesAutowired();
    
        this.ApplicationContainer = builder.Build();
        return new AutofacServiceProvider(this.ApplicationContainer);
      }
    }
