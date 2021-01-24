    public class A
    {
    	public A()
    	{
    		Console.WriteLine("A parameterless");
    	}
    	public A(int a) : this()
    	{
    		Console.WriteLine("A with a");
    	}
    }
    
    public class B : A
    {
    	public B()
    	{
    		ThingsIWant();
    	}
    	public B(int b) : base(b)
    	{
    		ThingsIWant();
    		Console.WriteLine("B with b");
    	}
    
    	protected void ThingsIWant()
    	{
    		Console.WriteLine("B paramterless");
    	}
    }
    
    public class Program
    {
    	public static void Main(string[] args)
    	{
    		new B(3);
    	}
    }
