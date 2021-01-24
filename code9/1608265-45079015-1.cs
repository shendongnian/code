    public static class QueryableExtension
    {
    	public static IQueryable<T> ToQueryable<T>(this T obj) where T : Entity
    	{
    		return new List<T> { obj }.AsQueryable();
    	}
    }
