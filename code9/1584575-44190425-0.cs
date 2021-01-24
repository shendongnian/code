    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var test = "This is \"a\" string";
    		
    		Console.WriteLine(test);
    		
    		test = test.Replace('\"', '\'');
    		
    		Console.WriteLine(test);
    	}
    }
