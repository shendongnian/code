    public class ApiModelDataContext : DbContext
    {
    	public DbSet<ApiToken> ApiTokens { get; set; }
    
    	public DbSet<ApiClient> ApiClients { get; set; }
    
    	public DbSet<ApiApplication> ApiApplications { get; set; }
    
    	public ApiModelDataContext() 
    		: base("ConnectionName")
    	{
    		Configuration.LazyLoadingEnabled = true;
    		Configuration.ProxyCreationEnabled = true;
    		Database.SetInitializer<ApiModelDataContext>(new Initializer<ApiModelDataContext>());
    		Database.Log = message => DBLog.WriteLine(message);
    	}
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		base.OnModelCreating(modelBuilder);
    	}
    }
