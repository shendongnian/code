    public class Program
    {
    	public static void Main()
    	{
    		Base ba = new A();
    		Do((dynamic)ba);
            ba = new B();
    		Do((dynamic)ba);
    	}
    	
    	public static void Do(A a)
    	{
    		System.Console.Write("A");
    	}
    	
    	public static void Do(B b)
    	{
    		System.Console.Write("B");
    	}
    }
    
    public class Base{}
    public class A : Base{}
    public class B : Base{}
