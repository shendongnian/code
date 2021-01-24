    public interface IStartup
    {
        IServiceProvider ConfigureServices(IServiceCollection services);
 
        void Configure(IApplicationBuilder app);
    }
