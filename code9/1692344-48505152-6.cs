	public static class Extensions
	{
		public static IQueryable<T> Filter<T>(this DemoContext instance, Expression<Func<T, bool>> predicate = null, string value = null)
			where T : class, IMarker
		{
			return instance
				.Set<T>()
				.Where(p => p.SomeProp == value)
				.Where(predicate);
		}
	}
