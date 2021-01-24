        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            var physicalProvider = _hostingEnvironment.ContentRootFileProvider;
            var embeddedProvider = new EmbeddedFileProvider(Assembly.GetEntryAssembly());
            var compositeProvider = new CompositeFileProvider(physicalProvider, embeddedProvider);
            // choose one provider to use for the app and register it
            //services.AddSingleton<IFileProvider>(physicalProvider);
            //services.AddSingleton<IFileProvider>(embeddedProvider);
            services.AddSingleton<IFileProvider>(compositeProvider);
        }
