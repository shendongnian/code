        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //register automapper
            services.AddAutoMapper(Assembly.GetAssembly(typeof(StatusMappingProfile))); //If you have other mapping profiles defined, that profiles will be loaded too.
