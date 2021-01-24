    using System;
     
    public class Test
    {
    	public static void Main()
    	{
    		// get input
    		var input = 0;
    		int.TryParse(Console.ReadLine(), out input);
     
    		// print first nth even numbers
    		var counter = 0;
    		while (counter < input)
    		{
    			counter++;
    			Console.WriteLine(counter * 2);
    		}
    	}
    }
