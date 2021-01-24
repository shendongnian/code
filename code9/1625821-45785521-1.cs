    public static IWebHost MigrateDatabase(this IWebHost webHost)
    {
        using (var scope = webHost.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
    
            try
            {
                var db = services.GetRequiredService<MyContext>();
                db.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    
        return webHost;
    }
    public static void Main(string[] args)
    {
        BuildWebHost(args)
            .MigrateDatabase()
            .Run();
    }
