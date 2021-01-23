        using WebApplication.Services;
        public void ConfigureServices(IServiceCollection services)
        {
            ...
            services.AddScoped<IViewRenderService, ViewRenderService>();
         }
