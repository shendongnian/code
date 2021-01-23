    using System;
    using System.Collections.Generic;
    
    public class Test
    {
    	public static void Main()
    	{
    		string input = string.Empty;
    		int output = 0;
    		do
    		{
    		    Console.WriteLine("Enter number: ");
    		    input = /* Console.ReadLine(); */ "8";
    		} while (!int.TryParse(input, out output));
    		int[] first = new int[] {0,1,2,3,4,5,6,7,8,9};
    		int[] second = new int[] {0,1,2,3,4,5,6,7,8,9};
    		var list = new List<string>();
    		for (int i = 0; i < first.Length; i++)
    			for (int j = 0; j < second.Length; j++)
    				if (first[i] * second[j] == output)
    					list.Add(first[i] + " x " + second[j] + " = " + output);
    		foreach (var str in list) {
    			Console.WriteLine(str);
    		}
    	}
    }
