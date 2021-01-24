    using System;
					
    public class Program
    {
	    public static void Main()
	    {
		    var thing1 = new object[] {"Thing1" };
		    var thing2 = new object[] {"Thing2" };
		    var parent = new object[] { thing1, thing2 };
		    var grandParent = new object[] { parent };
		
		    foreach(var parentNode in grandParent)
		    {
			    foreach(var childNode in (Array)parentNode)
			    {				
				    foreach(var thing in (Array)childNode)
				    {
					    Console.WriteLine(thing);
				    }				
			    }
		    }
	    }
    }
