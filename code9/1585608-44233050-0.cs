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
    		foreach (var child in children.Cast<T>())
    		{
    			if (child.Id == id)
    			{
    				return child;
    			}
    		}
    
    		return default(T);
    	}
    }
