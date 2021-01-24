    class SQLiteDbProviderFactoryResolver : IDbProviderFactoryResolver
    {
    	public static readonly SQLiteDbProviderFactoryResolver Instance = new SQLiteDbProviderFactoryResolver();
    	private SQLiteDbProviderFactoryResolver() { }
    	public DbProviderFactory ResolveProviderFactory(DbConnection connection)
    	{
    		if (connection is SQLiteConnection) return SQLiteProviderFactory.Instance;
    		if (connection is EntityConnection) return EntityProviderFactory.Instance;
    		return null;
    	}
    }
