    public class S<T> where T : A
    {
    	public void Method1(T o)
    	{
    		var a = (A)o;
    	}
    }
