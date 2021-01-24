	public class DbContextFactory : IDbContextFactory
	{
		private string _siteType;
		public DbContextFactory(ISiteContext siteContext)
		{
			_siteType = siteContext.SiteType;
		}
		
		public IocDbContext CreateContext()
		{
			return new IocDbContext(_siteType);
		}
		
		// or you can use this if you pass the ISiteContext dependency into your service
		public static IocDbContext CreateContext(string siteType)
		{
			return new IocDbContext(_siteType);
		}
	}
	
