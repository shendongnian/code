    public void ConfigureServices(IServiceCollection services) {
    ...
      services.AddSingleton<ISessionFactory>(c => {
        var config = new Configuration();
        ...
        return config.BuildSessionFactory();
      });
    ...
      services.AddSingleton<RoleServico>();
    ...
    }
