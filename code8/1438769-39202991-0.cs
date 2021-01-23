    using System;					
    public class Program
    {
    	public static void Main()
    	{
    		/// Wanted result 
    		/// 12-3456789-0
    		string s = "1234567890";
    		int i = int.Parse(s);
    		Console.WriteLine("Hello World");		
    		string test = string.Format("{0:0-#######-#}", i);
    		Console.WriteLine(test);
    		
    		/// But actual output 
    		/// 1234567890
    	}
    }
