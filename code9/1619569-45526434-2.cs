    public partial class StaticDataContext : DbContext
    {
    	public StaticDataContext()	{  	}
    	
    	//...
    	
    	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    	{
    		optionsBuilder.UseSqlite(@"Datasource=sqlite-latest.sqlite");
    	}
    	
    	//...
    }
