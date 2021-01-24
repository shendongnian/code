    using System;
    public class Program
    {
    	static private int a = 0;
    	static private int i = 0;
    	public static void Main()
    	{
    		for (i = 0; i < 100; i++){
    			a += i;
    			if (a == 595) break;
    		}
    		Console.WriteLine(i);
    	}
    }
