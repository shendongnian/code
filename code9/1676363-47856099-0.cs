    using System.Linq;
    using System;
    
    public class Program
    {
  	    public static void Main()
	    {
		    var a = new[]{"Apple", "Orange", "WaterMelon", "ApplE", "Orange", "APple"};
		    var b = a.Where(x => a.Count(i => i.Equals(x, StringComparison.OrdinalIgnoreCase )) == 1);
		
		    System.Console.WriteLine(string.Join(",", b));
	    }
    }
