    public static class MyRepository
    {
    	public static IQueryable<T> GetSomething<T>(IQueryable<T> source)
    		where T : class, IAbc
    	{
    		return source.Where(x => x.Abc == "hey");
    	} 
    }
