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
    		return children.Find(i => i.Id == id);
    	}
    }
