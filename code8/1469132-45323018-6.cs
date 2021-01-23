    public void ConfigureServices(IServiceCollection services)
            {
                // Add framework services.
                services.AddMvc();
    
                Orm.DatabaseConnection.ConnectionString = Configuration["ConnectionStrings:MyConnectionString"];
            }
