    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    class Solution 
    {
    	static void Main(String[] args) 
    	{
    		int n = int.Parse(Console.ReadLine()); // No reason to accept a double here
    
    		long factorial = 1; // Just use a long type
    		
    		for (int i = 1; i <= n; i++)
    		{
    			factorial *= i;
    		}
    
    		Console.WriteLine(factorial);
       }
    }
