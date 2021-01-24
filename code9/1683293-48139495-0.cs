    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		var t = 
                "WITH Date = {GETDATE()} AND Customer = 8824"
    			.Split(" ".ToCharArray(),            // add other unwanted chars to splitter
                       StringSplitOptions.RemoveEmptyEntries);  
    		
    		foreach(var part in t)
    			Console.WriteLine(part);
    	}
    }
