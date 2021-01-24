    using System.Collections.Generic;
    using System.Linq;
    
    public interface IHasId
    {
    	public int Id { get; }
    }
    
    public class Foo<T> where T : IHasId
    {
    	private List<T> children;
    
    	public TItem GetById<TItem>(int id)
	     	where TItem : T, IHasId
	    {
		    return children.Select(t => t is TItem).Cast<TItem>().FirstOrDefault(t => t.Id == id);
	    }
    }
