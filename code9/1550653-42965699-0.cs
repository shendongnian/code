    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Bar b = new Bar(); // Prints "Foo"
    		// Console.WriteLine(Foo.BaseField); // Compile error
    	}
    }
    
    public class Foo 
    {
    	protected static readonly string BaseeField = "Foo";
    }
    
    public class Bar : Foo
    {
    	public Bar()
    	{
    		Console.WriteLine(Foo.BaseeField);
    	}
    }
