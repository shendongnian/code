    public IServiceProvider ConfigureServices(IServiceCollection services) {
        var connection = @"Server=MyDb;Initial Catalog=MYDB;Persist Security Info=True; Integrated Security=SSPI;";
        services.AddDbContext<iProfiler_ControlsContext>(options => options.UseSqlServer(connection));
        //.........
        var provider = services.BuildServiceProvider();
        return provider;
    }
