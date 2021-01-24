         public class Startup
         {
           public Startup(IHostingEnvironment env)
           {
          var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }
    
        public IContainer ApplicationContainer { get; private set; }
    
        public IConfigurationRoot Configuration { get; private set; }
    
        // ConfigureServices is where you register dependencies. This gets
        // called by the runtime before the Configure method, below.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
        // Add services to the collection.
        services.AddMvc();
    
        // Create the container builder.
        var builder = new ContainerBuilder();
    
        // Register dependencies, populate the services from
        // the collection, and build the container. If you want
        // to dispose of the container at the end of the app,
        // be sure to keep a reference to it as a property or field.
        //
        // Note that Populate is basically a foreach to add things
        // into Autofac that are in the collection. If you register
        // things in Autofac BEFORE Populate then the stuff in the
        // ServiceCollection can override those things; if you register
        // AFTER Populate those registrations can override things
        // in the ServiceCollection. Mix and match as needed.
        builder.Populate(services);
        builder.RegisterType<MyType>().As<IMyType>();
        this.ApplicationContainer = builder.Build();
    
        // Create the IServiceProvider based on the container.
        return new AutofacServiceProvider(this.ApplicationContainer);
        }
    
        // Configure is where you add middleware. This is called after
        // ConfigureServices. You can use IApplicationBuilder.ApplicationServices
        // here if you need to resolve things from the container.
        public void Configure(
        IApplicationBuilder app,
        ILoggerFactory loggerFactory,
        IApplicationLifetime appLifetime)
        {
          loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
          loggerFactory.AddDebug();
    
          app.UseMvc();
    
          // If you want to dispose of resources that have been resolved in the
          // application container, register for the "ApplicationStopped" event.
          // You can only do this if you have a direct reference to the container,
          // so it won't work with the above ConfigureContainer mechanism.
          appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        }
        }
