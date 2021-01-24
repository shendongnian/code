            IServiceCollection services = new ServiceCollection();
            services.AddLogging(); // all the magic happens here
            // set up other services 
            var builder = new ContainerBuilder();
            builder.Populate(services); // from the Autofac.Extensions.DependencyInjection package
            IContainer container = builder.Build();
            Test t = container.Resolve<Test>();
