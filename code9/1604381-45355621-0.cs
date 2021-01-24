        public **IServiceProvider** ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDirectoryBrowser();            
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
           
            var builder = new ContainerBuilder();
            builder.Populate(services);
            ServiceLayerInstaller.ConfigureServices(builder);			         
                      
            WorkerRoleInstaller.ConfigureServices(builder);
           
            ApplicationContainer = builder.Build();
            var autofacJobActivator = new AutofacJobActivator(ApplicationContainer, false);
            GlobalConfiguration.Configuration.UseActivator(autofacJobActivator);
            **return new AutofacServiceProvider(ApplicationContainer);**
        }
