    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		    int[] myArr = new int[] { 10, 5, 5, 3, 3, 3 };
                // int counter = 0; - now this is no longer needed
    
                var numbersThatAreDuplicates = myArr.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => new { number = x.Key, countOfNumber = x.Count()}).ToList();
    
                Console.WriteLine("There are {0} repeating values in the array.", numbersThatAreDuplicates.Count);
                foreach (var item in numbersThatAreDuplicates)
                {
                    Console.WriteLine(item.number + " repeats itself " + item.countOfNumber + " times.");
                } 
    	}
    }
    // Output
    // There are 2 repeating values in the array.
    // 5 repeats itself 2 times.
    // 3 repeats itself 3 times.
