    void Main()
    {
    	//Prints null
    	Console.WriteLine(Derived.Instance?.Name);
    	
    	//Prints Derived
    	var a = Derived.InitDerived;
    	Console.WriteLine(Derived.Instance?.Name);
    	
    	//Prints Derived2
    	var b = Derived2.InitDerived;
    	Console.WriteLine(Derived.Instance?.Name);
    }
    
    public class Base
    {
    	public string Name { get; set; }
    	protected static Base _instance;
    	public static Base Instance
    	{
    		get
    		{
    			return _instance;
    		}
    	}
    }
    public class Derived : Base
    {
    	public static int InitDerived = 1;
    	static Derived()
    	{
    		_instance = new Derived() { Name = "Derived" };
    	}
    }
    
    public class Derived2 : Base
    {
    	public static int InitDerived = 2;
    	static Derived2()
    	{
    		_instance = new Derived()  { Name = "Derived2" };
    	}
    }
