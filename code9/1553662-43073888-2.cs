    using System;
    
    public class Program
    {
        // Here we instantiate or construct a new instance of ThingWithMessage
        // but we refer to it by as thing of type IMyInterface,
        // this works because ThingWithMessage implements IMyInterface.
        // Then we use the interface to get a message and
        // write it to the console.
    	public static void Main()
    	{
    		IMyInterface thing = new ThingWithMessage();
    		Console.WriteLine(thing.GetMessage());
    	}    
    }
    
    // This defines a type, or contract that classes can implement
    interface IMyInterface
    {
    	string GetMessage();
    }
        
    // This is a class that implements the IMyInterface interface
    // effectively, it makes a promised to keep the contract
    // specified by IMyInterface.
    class ThingWithMessage : IMyInterface
    {
    	public string GetMessage()
    	{
    		return "yes, this works.";
    	}
    }
    
