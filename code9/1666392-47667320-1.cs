    var host = BuildWebHost(args);
    
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
    
        try
        {
            // Requires using RazorPagesMovie.Models;
            SeedData.Initialize(services);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred seeding the DB.");
        }
    }
    
    host.Run();
