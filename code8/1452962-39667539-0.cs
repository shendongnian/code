	public class GenericRepository<T> where T : class
	{
		private DbContext _context = null;
		private DbSet<T> _entities = null;
		public GenericRepository(DbContext context)
		{
			_context = context;
			_entities = context.Set<T>();
		}
	}
