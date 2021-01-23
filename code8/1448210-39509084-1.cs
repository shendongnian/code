	public class BService : IBService
	{
		IADbContext _dbContext =>  _dbContextFactory.GetInstance();
		IFactory<IADbContext> _dbContextFactory
		
		public BService(IFactory<IADbContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}
	}
