    public class MyDbContext: DbContext
    {
    
    	#region ..:: Fields ::..
    
    	private static readonly string DataBaseContext = ConfigurationManager.AppSettings["DataBaseContext"];
    
    	#endregion
    
    	#region ..:: Construtor ::..
    
    	public MyDbContext()
    		: base(DataBaseContext)
    	{
    		//Database.CreateIfNotExists();
    	}
    
    	#endregion
    
    	..........
    	
    	protected override void OnModelCreating(DbModelBuilder modelBuilder) 
    	{
    		........
    	}
    
    }
