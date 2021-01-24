    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
      //////// 
      public DataContext CreateDbContext(string[] args)
      {
        var builder = new DbContextOptionsBuilder<DataContext>(); 
        IConfigurationRoot configuration = new ConfigurationBuilder()  
          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)       
          .AddJsonFile("appsettings.json")
          .Build();
        builder.UseSqlServer(configuration.GetConnectionString("Defa‌​ultConnection")); 
        return new DataContext(builder.Options); 
      }
 
    }
