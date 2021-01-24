    public void ConfigureServices(IServiceCollection services)
    {
          services.AddDbContext<MyContext>(options =>
              options.UseSqlite("Data Source=" + 
              Path.Combine(Directory.GetCurrentDirectory(), "Data\\sqlite.db"))
          );
    }
 
