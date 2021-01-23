	public class ApplicationInfo
	{
		private static readonly Lazy<ApplicationInfo> _instance = new Lazy<ApplicationInfo>(() => new ApplicationInfo());
		public static ApplicationInfo Instance
		{
			get { return _instance.Value; }
		}
		public string NWatchDatabaseServer { get; set; }
		public string NWatchDatabaseCatalog { get; set; }
		public string EntityDatabaseServer { get; set; }
		public string EntityDatabaseCatalog { get; set; }
		private ApplicationInfo()
		{
			//ASSIGN VALUES HERE
			NWatchEntityApplication nWatchApp = new NWatchEntityApplication(GetNWatchConfig());
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(nWatchApp.Configuration.NWatchDatabase);
			Infrastructure.ApplicationInfo.NWatchDatabaseCatalog = builder.InitialCatalog;
			Infrastructure.ApplicationInfo.NWatchDatabaseServer = builder.DataSource;
			var context = nWatchApp.GetDbContext();
			builder = new SqlConnectionStringBuilder(context.DatabaseConnectionString);
			Infrastructure.ApplicationInfo.EntityDatabaseCatalog = builder.InitialCatalog;
			Infrastructure.ApplicationInfo.EntityDatabaseServer = builder.DataSource;
		}
	}
