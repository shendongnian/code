    public class DataContextB : DbContext
    {
    	public DbSet<Person> People {get;set;}
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		modelBuilder.Entity<Person>().Property(t => t.ID)
    					.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    
    		base.OnModelCreating(modelBuilder);
    	}
    }
