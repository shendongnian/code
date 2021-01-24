	public class StubLocationRepository : ILocationRepository
	{
		private readonly Location _findByInclude;
		public StubLocationRepository(Location findByInclude)
		{
			_findByInclude = findByInclude;
		}
		public Location FindByInclude(
			Expression<Func<Location, bool>> predicate,
	        params Expression<Func<Location, object>>[] includeProperties)
	    {
	    	return _findByInclude;
	    }
	}
