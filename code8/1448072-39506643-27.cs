    public class TestContext : DbContext
    {
    	public DbSet<Settings> Settings { get; set; }
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		base.OnModelCreating(modelBuilder);
    		modelBuilder
    			.Entity<Settings>()
    			.BinaryProperty("_Hash")
    			.HasColumnName("Hashtable");
    	}		
    }
