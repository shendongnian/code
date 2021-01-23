    public void ConfigureServices(IServiceCollection services)
    {
         services.AddDbContext<ViewDbContext>(options => 
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        ...
         /* Add  EntityFrameworkFileProvider to Razor engine */       
         var context = services.BuildServiceProvider()
                           .GetService<ViewDbContext>();
         services.Configure<RazorViewEngineOptions>(opts =>
         {
             opts.FileProviders.Add(new EntityFrameworkFileProvider(context));
         });
         services.AddMvc();
    }
