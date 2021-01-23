    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		int n = 3;
    		object o1 = n;
    		object o2 = n;
    		Console.WriteLine("o1 == o2 is {0}", o1 == o2);
    		Console.WriteLine("o1.Equals(o2) is {0}", o1.Equals(o2));
    		Console.WriteLine("(int)o1 == (int)o2 is {0}", (int)o1 == (int)o2);
    		
    	}
    }
