    public partial class StaticDataContext : DbContext
    {
    	public StaticDataContext(DbContextOptions<StaticDataContext> options) : base(options)
    	
    	//...
    	
    	//Removed as it's being injected in to the ctor via DI
    	//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    	//{
    	//	optionsBuilder.UseSqlite(@"Datasource=sqlite-latest.sqlite");
    	//}
    	
    	//...
    }
