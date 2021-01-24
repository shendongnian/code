    using System;
    using System.Text.RegularExpressions;
    public class Program
    {
	    public static void Main()
	    {
		    var Regla = "{!( !A && A) ( !A && !A )}";
		
		    var output = Regex.Replace(Regla, "([A-Z])", "!$1").Replace("!!", "");
		
    		Console.WriteLine(output);
	    }
    }
