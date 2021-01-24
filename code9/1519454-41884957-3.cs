	public class StubLocationRepository : ILocationRepository
	{
		private readonly IEnumerable<Location> _findByInclude;
		public StubLocationRepository(IEnumerable<Location> findByInclude)
		{
			_findByInclude = findByInclude;
		}
		public IEnumerable<Location> FindByInclude(
			Expression<Func<Location, bool>> predicate,
	        params Expression<Func<Location, object>>[] includeProperties)
	    {
	    	return _findByInclude;
	    }
	}
