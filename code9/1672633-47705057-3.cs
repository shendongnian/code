    public class MyContext : DbContext
    {
    	public virtual IDbSet<MyEntity> MyEntities { get; set; }
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		modelBuilder.Entity<MyEntities>()
    			.Map(m => m.Requires("IsDeleted")).HasValue(false).Ignore(m => m.IsDeleted);
    	}
    }
