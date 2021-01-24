	public class DbContextFactory
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
		
		public static IocDbContext CreateContext(string siteType)
		{
			return new IocDbContext(_siteType);
		}
	}
