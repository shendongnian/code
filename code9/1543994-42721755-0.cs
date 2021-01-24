    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		var arrayOfWordsToSplitOn = new List<string> { "cat", "dog" };
        	var s = "My cat and my dog are very lazy";
        	var pattern = string.Format(@"\s*\b({0})\b\s*", string.Join("|", arrayOfWordsToSplitOn));
        	var results = Regex.Split(s, pattern).Where(x => !String.IsNullOrWhiteSpace(x)).ToList();
            foreach (var res in results)
            	Console.WriteLine(res);
    	}
    }
