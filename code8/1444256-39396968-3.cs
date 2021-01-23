    static void Main(string[] args)
    {
      var trackingModule = new TrackingModule();
    
      var builder = new ContainerBuilder();
      // Register types, then register the module
      builder.RegisterType<Consumer>().As<IConsumer>();
      builder.RegisterType<DisposableDependency>().As<IDependency>();
      builder.RegisterType<NonDisposableDependency>().As<IDependency>();
      builder.RegisterModule(trackingModule);
      var container = builder.Build();
    
      // Do whatever it is you want to do...
      using (var scope = container.BeginLifetimeScope())
      {
        scope.Resolve<IConsumer>();
      }
    
      // Dump data
      Console.WriteLine("Activation totals:");
      trackingModule.WriteActivations();
    }
