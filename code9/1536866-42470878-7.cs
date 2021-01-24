	public class DbAccess
	{
		private IDbContextFactory _dbContextFactory;
		public DbAccess(IDbContextFactory dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}
		public void DoWork()
		{
			using (IocDbContext db = _dbContextFactory.CreateContext())
			{
				// use EF here...
			}
		}	
	}
