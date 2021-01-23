    using System;
    using System.Linq;
	    	    			
    public class Program
    {
	    public static void Main()
	    {
		    string s = "aasfkkfasfas";
		    int count = s.Count(l => l== 'k');
		    
		    Console.WriteLine(count);
	    }
    }
    
