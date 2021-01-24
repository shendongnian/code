    public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            var builder = new ContainerBuilder();
            //  builder.RegisterModule<DataModule>();
            builder.RegisterType<Class1>().As<InterfaceA>();
            builder.RegisterType<Class2>().As<InterfaceA>();
            builder.Populate(services);
            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }
