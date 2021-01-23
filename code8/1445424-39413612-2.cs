    using System;
    					
    public class Program
    {
    	static public string RandomDigits(int length)
    		{
    			var random = new Random();
    			string s = string.Empty;
    			char[] alphabets = { 'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
    	
    			for (int i = 0; i < length; i++)
    				s = String.Concat(s, alphabets[random.Next(0,26)].ToString()+" ");
    	
    			Console.WriteLine(s);
    			return s;
    		}	
    	
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		Console.WriteLine(RandomDigits(7));
    		
    	}
    	
    	
    }
