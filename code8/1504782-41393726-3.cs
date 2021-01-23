        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<RazorViewEngineOptions>(options => {
                options.ViewLocationExpanders.Add(new MyViewLocationExpander());
            });
        }
