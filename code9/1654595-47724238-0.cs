    public static void Main(string[] args)
    {
        // REPLACE THIS:
        // BuildWebHost(args).Run();
     
        // WITH THIS:
        var host = BuildWebHost(args);
        using (var scope = host.Services.CreateScope())
        {
            // Retrieve your DbContext isntance here
            var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
     
            // place your DB seeding code here
            DbSeeder.Seed(dbContext);
        }
        host.Run();
     
        // ref.: https://docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/
    }
     
    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
