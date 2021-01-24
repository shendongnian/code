      public void ConfigureServices(IServiceCollection services)
        {
             services.AddDbContext<TipoEquipoContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
    
