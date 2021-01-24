    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		IMyInterface thing = new ThingWithMessage();
    		Console.WriteLine(thing.GetMessage());
    	}    
    }
    
    interface IMyInterface
    {
    	string GetMessage();
    }
        
    class ThingWithMessage : IMyInterface
    {
    	public string GetMessage()
    	{
    		return "yes, this works.";
    	}
    }
    
