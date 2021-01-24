    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		// Two distinct GUIDs
    		Guid g1 = new Guid("{10349469-c6f7-4061-b2ab-9fb4763aeaed}");
    		Guid g2 = new Guid("{45DF902E-2ECF-457A-BB0A-E04487F71D63}");		
    		
    		// GUID similar to 'g1' but with mixed case
    		Guid g1a = new Guid("{10349469-c6f7-4061-b2ab-9fb4763AEAED}");
    		
    		// GUID similear to 'g1' but without braces
    		Guid g1b = new Guid("10349469-c6f7-4061-b2ab-9fb4763AEAED");
    		
    		// Show string value of g1,g2 and g3
    		Console.WriteLine("g1 as string: {0}\n", g1.ToString());
    		Console.WriteLine("g2 as string: {0}\n", g2.ToString());
    		Console.WriteLine("g1a as string: {0}\n", g1a.ToString());
    		Console.WriteLine("g1b as string: {0}\n", g1b.ToString());
    		
    		// g1 to g1a match result
    		bool resultA = (g1.ToString() == g1a.ToString());
            // g1 to g1b match result
    		bool resultB = (g1.ToString() == g1b.ToString());
    		
    		// Show match result
    		Console.WriteLine("g1 matches to g1a: {0}\n", resultA );
    		Console.WriteLine("g1 matches to g1b: {0}", resultB );		
    	}
    }
