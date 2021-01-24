    services.AddDbContext<ApplicationContext>(options => 
      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    services.AddTransient<IUserService, UserService>();
    services.AddTransient<IUserProfileService, UserProfileService>();
