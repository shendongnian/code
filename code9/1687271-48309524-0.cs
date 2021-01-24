    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var dec = 62.25m;
    		var ts = TimeSpan.FromHours((double)dec);
    		
    		Console.WriteLine("{0} Hours, {1} Minutes", Math.Floor(ts.TotalHours), ts.Minutes);
    	}
    }
