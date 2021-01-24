    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		string[] a = { "x", "y" };
            string[] b = { "x" };
            
            int first = a?.Length ?? 0 + b?.Length ?? 0;
            int second = (a?.Length ?? 0) + (b?.Length ?? 0);
            Console.WriteLine(first);   // Prints 2
            Console.WriteLine(second);  // Prints 3
    	}
    }
