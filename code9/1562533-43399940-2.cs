    public class StudentContext : DbContext
    {
    	public StudentContext(string connectionString) : base(connectionString)
    	{
    	}
    	
    	protected override void OnModelCreating(DBModelBuilder modelBuilder)
    	{
    		base.OnModelCreating(modelBuilder);
    		System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentContext, StudentMigrations.Configuration>(true)); //Passing true here to reuse the client context triggering the migration 
    	}
    	
    	public DbSet<Student> Students {get; set;} 
    }
