    public class MyContext : DbContext
    {
    	public virtual IDbSet<MyEntity> MyEntities { get; set; }
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		modelBuilder.Entity<MyEntities>()
    			.Ignore(m => m.IsDeleted);
    	}
    }
