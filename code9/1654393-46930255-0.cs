     public void ConfigureServices(IServiceCollection services)
     {
       services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase()
       );
       services.AddScoped<IRepository, MemoRepostory>();
  
     }
