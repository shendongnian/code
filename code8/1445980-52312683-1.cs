    public class DbFactory: Disposable, IDbFactory
	{
		BlogContext dbContext;		
		
		public BlogContext Init()
		{
			return dbContext ?? (dbContext = new BlogContext( NEEDOPTIONS ));
		}
		protected override void DisposeCore()
		{
			if (dbContext != null)
				dbContext.Dispose();
		}
	}
