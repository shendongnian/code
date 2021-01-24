    public void ConfigureServices(IServiceCollection services) {
        services.AddDbContext<MyProjectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyProjectContext")));
        services.AddHangfire(options => options.UseSqlServerStorage(Configuration.GetConnectionString("MyProjectContext")));
        services.AddOptions();
        services.Configure<MySettings>(options => Configuration.GetSection("MySettings").Bind(options));
        services.AddMvc().AddDataAnnotationsLocalization();
        //...adding additional services
        services.AddScoped<IMyProjectContext, MyProjectContext>();
        services.AddTransient<IFileSystem, FileWrapper>();
        services.AddTransient<MyClass, MyClass>();
    }
