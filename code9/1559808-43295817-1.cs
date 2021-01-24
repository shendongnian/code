    using System;
    public class Program
    {
    	public static void Main()
    	{
    		for (int i = 0; i < 100; i++)
    		{
    			try
    			{
    				if (i == 10)
    				{
    					break;
    				}
    
    				Console.WriteLine(i);
    			}
    			catch
    			{
    				Console.WriteLine("Catch");
    			}
    			finally
    			{
    				Console.WriteLine("finally");
    			}
    		}
    	}
    }
