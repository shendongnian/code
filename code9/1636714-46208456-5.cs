    public void ConfigureServices(IServiceCollection services)
            {
                services.AddDbContext<ApplicationContext>();
                services.AddScoped<ItemService>();         
            }
