DbInitializer.Initialize(app.ApplicationServices);
    public static async void Initialize(IServiceProvider services)
    {
        using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
            var manager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var user = new ApplicationUser { UserName = "abc@xxx.com" };
            var result = await manager.CreateAsync(user, "password");
        }
    }
