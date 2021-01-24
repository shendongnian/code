    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppContext>
    {
       public AppContext CreateDbContext(string[] args)
       {
    	   // IDesignTimeDbContextFactory is used usually when you execute EF Core commands like Add-Migration, Update-Database, and so on
    	   // So it is usually your local development machine environment
    	   var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    
    	   // Prepare configuration builder
    	   var configuration = new ConfigurationBuilder()
    		   .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
    		   .AddJsonFile("appsettings.json", optional: false)
    		   .AddJsonFile($"appsettings.{envName}.json", optional: false)
    		   .Build();
    
    	   // Bind your custom settings class instance to values from appsettings.json
    	   var settingsSection = configuration.GetSection("Settings");
    	   var appSettings = new AppSettings();
    	   settingsSection.Bind(appSettings);
    
    	   // Create DB context with connection from your AppSettings 
    	   var optionsBuilder = new DbContextOptionsBuilder<AppContext>()
    		   .UseMySql(appSettings.DefaultConnection);
    
    	   return new AppContext(optionsBuilder.Options);
       }
    }
