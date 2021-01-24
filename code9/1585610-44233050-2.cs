    using System.Collections.Generic;
    using System.Linq;
    
    public interface IHasId
    {
    	public int Id { get; }
    }
    
    public class Foo<T> where T : IHasId
    {
    	private List<T> children;
    
    	public T GetById(int id)
    	{
            //Find will return the first item matching the predicate or default(T)
            //See: https://msdn.microsoft.com/en-us/library/x0b5b5bc(v=vs.110).aspx
            //Notice that if the method returns a generic you won't be able to return null, you should return default(t)
    		return children.Find(i => i.Id == id);
    	}
    }
