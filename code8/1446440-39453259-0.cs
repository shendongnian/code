    public static void Initialize(IServiceProvider services)
    {
        using (var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>())
        {
            ...
        }
    }
