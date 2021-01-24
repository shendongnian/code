    public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
            .AddRazorOptions(options =>
            {
                options.ViewLocationExpanders.Add(new ViewLocationExpander());
            });
        }
