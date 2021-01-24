    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
            // example string
    		var myString = "The sun is bright. The sun is yellow";
    		
            // split the string into an array based on space characters and the period
    		var stringArray = myString.Split(new char[] {' ', '.'}, StringSplitOptions.RemoveEmptyEntries);
    		
            // group the items in the array based on the value, then create an anonymous class with the properties `Word` and `Count`
    		var groupedWords = stringArray.GroupBy(x => x).Select(x => new { Word = x.Key, Count = x.Count() }).ToList();
    		
            // print the properties based on order of largest to smallest count to screen
    		foreach(var item in groupedWords.OrderByDescending(x => x.Count))
    		{
    			Console.WriteLine(item.Word + " = " + item.Count);
    		}
            // Output
            ---------
            // The = 2
            // sun = 2
            // is = 2
            // bright = 1
            // yellow = 1
    	}
    }
