    public void ConfigureServices(IServiceCollection services) {
        services.AddMvc(options => {
            options.Filters.Add(typeof(CustomActionFilter)); // by type        
        });
        
        services.AddScoped<CustomActionFilter>();
    
        //...
    }
