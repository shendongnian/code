        public void ConfigureServices(IServiceCollection services)
        {
            // other registered services
            ...
            services.AddHangfire(c => c.UseMemoryStorage());
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // other pipeline configuration            
            ...
            app.UseHangfireServer();
            app.UseMvc();
        }
