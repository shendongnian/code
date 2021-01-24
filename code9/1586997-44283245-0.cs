    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Action actionOne = () => { Console.WriteLine("One"); };
    		Action<int> actionTwo = (int foo) => { Console.WriteLine("Two " + foo); };
    		
    		actionOne?.Invoke();
    		actionTwo?.Invoke(12);
    		
    		actionOne = null;
    		
    		Console.WriteLine("One is null");
    		
    		actionOne?.Invoke();
    		actionTwo?.Invoke(12);
    		
    		actionTwo = null;
    		
    		Console.WriteLine("Two is null");
    		
    		actionOne?.Invoke();
    		actionTwo?.Invoke(12);
    		
    		Console.WriteLine("Done");
    	}
    }
