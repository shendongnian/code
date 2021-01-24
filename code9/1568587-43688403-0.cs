    public class SQLiteProviderInvariantName : IProviderInvariantName
    {
    	public static readonly SQLiteProviderInvariantName Instance = new SQLiteProviderInvariantName();
    	private SQLiteProviderInvariantName() { }
    	public const string ProviderName = "System.Data.SQLite.EF6";
    	public string Name { get { return ProviderName; } }
    }
    class SQLiteDbDependencyResolver : IDbDependencyResolver
    {
    	public object GetService(Type type, object key)
    	{
    		if (type == typeof(IProviderInvariantName)) return SQLiteProviderInvariantName.Instance;
    		if (type == typeof(DbProviderFactory)) return SQLiteProviderFactory.Instance;
    		return SQLiteProviderFactory.Instance.GetService(type);
    	}
    
    	public IEnumerable<object> GetServices(Type type, object key)
    	{
    		var service = GetService(type, key);
    		if (service != null) yield return service;
    	}
    }
    class SQLiteDbConfiguration : DbConfiguration
    {
    	public SQLiteDbConfiguration()
    	{
    		AddDependencyResolver(new SQLiteDbDependencyResolver());
    	}
    }
