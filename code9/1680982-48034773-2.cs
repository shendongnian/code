    using System;
    using System.Collections.Generic;
    
    public class Program
    {	 
    	public static void Main()
    	{
    		Random x= new Random();
            
    		List<int> ints = new List<int>();
    		
    		for(int i=0; i< 100; i++) ints.Add(x.Next(4));
    		
    		Console.WriteLine(string.Join(", ",ints));
    	}
    }
