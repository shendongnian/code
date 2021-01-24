    public class SampleDbContext: DbContext
    {
    	public SampleDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
    	{
    		((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
    	}
    }
