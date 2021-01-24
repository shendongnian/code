        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // Default dependencies
            services.AddHealthApi();
            // Custom dependencies
            //services.AddHealthApi(healthApi => 
            //    healthApi.WithFoo(new MyFoo()).WithBar(new MyBar()));
        }
