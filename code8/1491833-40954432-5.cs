    public class MyRepository<T> where T : class
    {
    	public IQueryable<T> GetSomething()
    	{
    		if (typeof(IAbc).IsAssignableFrom(typeof(T)))
    		{
    			return MyRepository.GetSomething((dynamic)DbSet<T>());
    		}
    		// ...
    	}
    }
