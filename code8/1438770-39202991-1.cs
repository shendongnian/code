    using System;					
    public class Program
    {
    	public static void Main()
    	{
    		string s = "1234567890";
    		int i = int.Parse(s);
    		Console.WriteLine("Hello World");		
    		string test = string.Format("{0:0-#######-#}", i);
    		Console.WriteLine(test);    		
    	}
    }
