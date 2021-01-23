    public void ConfigureServices(IServiceCollection services) {
        ...
        services.AddDbContext<GameContext>(options => options.UseSqlServer(@"Data Source=DESKTOP-USER\SQLEXPRESS;Initial Catalog=Db7;Integrated Security=True;Connect Timeout=30;"));
        // Add application services.
        services.AddTransient<IAuthenticationService, Authentication>();
    }
