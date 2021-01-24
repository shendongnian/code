    using System;
    using System.Collections;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{	
    		foreach(var item in GetMyEnumerable())
    		{
    			Console.WriteLine(item);
    		}
    	}	
    	
    	public static IEnumerable GetMyEnumerable()
    	{
    		Console.WriteLine("how many times this method is called ?");		
    		foreach(var i in Enumerable.Range(1, 10))
    		{
    			yield return i;
    		}
    	}		
    }
