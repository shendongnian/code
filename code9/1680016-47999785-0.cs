    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<int> list = new List<int>(){ 2, 3, 7 };
    		
    		Console.WriteLine("List size: {0}", list.Count);
    		Console.WriteLine("List has '1': {0}", list.Contains(1));
    		Console.WriteLine("List has '2': {0}", list.Contains(2));
    		Console.WriteLine("List has '3': {0}", list.Contains(3));
    	}
    }
