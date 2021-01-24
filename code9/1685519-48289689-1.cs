    public partial class InheritedContext : DbContext
	{
		public InheritedContext() :
			base("DatabaseConnectionString")
		{
			Database.Log = DatabaseLogger.LogDebug;
			this.Configuration.LazyLoadingEnabled = false;
		}
