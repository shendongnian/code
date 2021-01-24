    public class MyDbContextFactory : IDbContextFactory<MyDbContext>
    {
    	private IConfigurationRoot _configuration;
    
    	public MyDbContextFactory()
    	{
    		var builder = new ConfigurationBuilder()
    			.SetBasePath(System.AppContext.BaseDirectory)
    			.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    
    		_configuration = builder.Build();
    	}
    
    	public MyDbContext Create()
    	{
    		var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
    		optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), m => { m.EnableRetryOnFailure(); });
    
    		return new MyDbContext(optionsBuilder.Options);
    	}
    }
