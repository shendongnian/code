    using System;
    public class Program
    {
    	public static void Main()
    	{
    		var Name = "Mosh";
    		var FName = Name;
    		Console.WriteLine(Object.ReferenceEquals(Name,FName));
    		
    		FName = "Hello";
    		System.Console.WriteLine(Name);
    		System.Console.WriteLine(FName);
    		Console.WriteLine(Object.ReferenceEquals(Name,FName));
    		
    		TestFunc(Name);
    		System.Console.WriteLine(Name);	
    		
    		RefFunc(ref FName);
    		System.Console.WriteLine(FName);	
    	}
    	
    	public static void TestFunc(string test)
        {
            test = "after passing";
        }
    	
    	public static void RefFunc(ref string test)
        {
            test = "after passing";
        }
    }
