    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var foo = new List<string>();
    		
    		var bar = foo.Count() == 0
    			? null
    			: from f in foo select f;
    
    		Console.WriteLine(bar == null); // true
    	}
    }
