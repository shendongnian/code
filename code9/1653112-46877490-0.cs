    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(30));
        services.AddMvc();
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseSession();  // This line is needed
        
        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        });
    }
