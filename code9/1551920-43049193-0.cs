    public interface IFoo<out T> {}
    public class C {}
    public class Program
    {
    	public static bool Contains<T>(IFoo<T> items, T item) 
    	{
    		System.Console.WriteLine(typeof(T));
    		return true; 
    	}
    	public static void Main()
    	{
    		IFoo<HttpMethod1> m1 = null;
    		IFoo<HttpMethod2> m2 = null;
    		var res1 = Contains(m1, new C()); //works
    		var res2 = Contains(m2, new C()); //doesn't work
    	}
        }
