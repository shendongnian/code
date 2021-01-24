    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static IEnumerable<string> SplitIt(
            char[] splitters, 
            string text, 
            StringSplitOptions opt = StringSplitOptions.None)
    	{
    		bool inside = false;
    		var result = text.Aggregate(new List<string>(), (acc, c) =>
    		{
                // this will check each char of your given text
                // and accumulate it in the (empty starting) string list
                // your splitting chars will lead to a new item put into 
                // the list if they are not inside. inside starst as false
                // and is flipped anytime it hits a "
                // at end we either return all that was parsed or only those
                // that are neither null nor "" depending on given opt's
    			if (!acc.Any()) // nothing in yet
    			{
    				if (c != '"' && (!splitters.Contains(c) || inside))
    					acc.Add("" + c);
    				else if (c == '"')
    					inside = !inside;
    				else if (!inside && splitters.Contains(c)) // ",bla"
    					acc.Add(null);
    
    				return acc;
    			}
    
    			if (c != '"' && (!splitters.Contains(c) || inside))
    				acc[acc.Count - 1] = (acc[acc.Count - 1] ?? "") + c;
    			else if (c == '"')
    				inside = !inside;
    			else if (!inside && splitters.Contains(c)) // ",bla"
    				acc.Add(null);
    
    			return acc;
    		}
    
    		);
    		if (opt == StringSplitOptions.RemoveEmptyEntries)
    			return result.Where(r => !string.IsNullOrEmpty(r));
    		return result;
    	}
    
    	public static void Main()
    	{
    		var s = ",,Degree,Graduate,08-Dec-17,Level 1,\"Advanced, Maths\",,";
    		var spl = SplitIt(new[]{','}, s);
    		var spl2 = SplitIt(new[]{','}, s, StringSplitOptions.RemoveEmptyEntries);
    		Console.WriteLine(string.Join("|", spl));
    		Console.WriteLine(string.Join("|", spl2));
    	}
    }
