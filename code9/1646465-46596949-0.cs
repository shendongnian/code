    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    	string x = @"Venue:~SOLDOTNA
    Cross Streets~
    DEAD END / STERLING HWY
     S KOBUK ST
    Phone:~(999) 999-9999";
    		
    		
    	    string[] allResults = 	x.Split( new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToArray();
    		foreach(string y in allResults)
    		{
    			Console.WriteLine(y + " = " +y.Length);
    		}
    		
    		
    		Console.WriteLine();
    		
    		
    		if(allResults.Contains("Cross Streets~") && allResults.Length >  Array.IndexOf(allResults,"Cross Streets~")+1 )
    		{
    			Console.WriteLine( "Expeced Result : " +  allResults[ Array.IndexOf(allResults,"Cross Streets~")+1 ]);
    		}
    		
    	}
    }
