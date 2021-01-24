    public static void Main(string[] args) {
        var host = BuildWebHost(args);
        using (var scope = host.Services.CreateScope()) {
            var services = scope.ServiceProvider;
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            DbInitializer.CreateAdmin(userManager, roleManager).Wait();
        }
        host.Run();
    }
