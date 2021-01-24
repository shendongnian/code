    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		var sc = new SomeClass();
    		sc.ToString(); // works
    		// does not work because SomeClass does not have a ToString method
    		/// which takes one parameter
    		sc.ToString("whatever");
    	}
    }
    
    public class SomeClass
    {
    }
