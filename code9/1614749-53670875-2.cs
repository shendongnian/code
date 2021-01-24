    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
        services
            .AddIdentity<User, Role>()
            .AddUserStore<MyUserStore>()
            .AddRoleStore<MyRoleStore>();
    }
