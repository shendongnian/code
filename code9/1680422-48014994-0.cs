    using System;
    using System.Threading;
    using System.Diagnostics;
    					
    public class Program
    {
    	public static TimeSpan StopFunc(Action act)
    	{
    		var watch = Stopwatch.StartNew();
    		
    		act?.Invoke();
    		
    		watch.Stop();
    		return watch.Elapsed;
    	} 
    	
    	static void Fast()
    	{
    		Thread.Sleep(100);
    	}
    	
    	static void Slow()
    	{
    		Thread.Sleep(2000);
    	}
    	
    	public static void Main()
    	{
            // this calls the "to be measured function"  
            // via lambda and prints the time needed
    		Console.WriteLine("Slow took: " + StopFunc( () => Slow()));
    		Console.WriteLine("Fast took: " + StopFunc( () => Fast()));		 
    	}
    }
