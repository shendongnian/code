    using System;	
    public class Program
    {
    	public static double Decode(string a)
        {    
            return double.Parse(a);
        }
    	
    	public static void Main()
    	{
    		var decoded = (Decode("2.1"));
    		
    		Console.WriteLine(decoded);
    	}    		
    }
