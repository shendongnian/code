    void Main()
    {
    	var x = new List<A>();
    	IEnumerable<I> y = x; // Fine
    	ICollection<I> z = x; // Compile Error
    }
    
    public class A : I { }
    
    public interface I { }
