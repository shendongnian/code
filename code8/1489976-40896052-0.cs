    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		int upper = 0;
    		int lower = 0;
    		
    		string upperLowerCase = "This Is A Test";
    		
    		char[] splitString = upperLowerCase.ToCharArray();
    		
    		for(int i = 0; i < splitString.Length; i++)
    		{
    			if(char.IsUpper(splitString[i]))
    			{
    				upper++;	
    			}
    			else
    			{
    				lower++;	
    			}
    				
    		}
    		
    		Console.WriteLine("Total Upper Case Letters: " + upper.ToString());
    		Console.WriteLine("Total Lower Case Letters: " +lower.ToString());
    	}
    }
    // Output
    // Total Upper Case Letters: 4
    // Total Lower Case Letters: 10
