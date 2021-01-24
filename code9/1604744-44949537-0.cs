    public abstract class Parent<T> where T : class, new()
    {
    	public T Find(string id) 
    	{
    		return new T();
    	}
    }
    public class Child  : Parent<Child>
    {
    	public void Test()
    	{
    		var child = base.Find ("");
    	}
    }
