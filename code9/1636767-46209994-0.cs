    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		DateTime? actualStartDate = DateTime.Now;
    		
    		if(actualStartDate.HasValue)
    		{
    			string s = actualStartDate.Value.ToString("yyyy-MM-dd");
    		    Console.WriteLine("value: " + s);
    		}		
    	}
    }
