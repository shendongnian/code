    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		List<string> files = new List<string>();
    		files.Add("AB_DBER_2016101194814.txt");
    		files.Add("AB_EBER_2016101194815.txt");
    		files.Add("AB_FBER_2016101194811.txt");
    		List<string> refFiles = new List<string>();
    		refFiles.Add("AB_DBER_[0-9]{13,13}.txt");
    		refFiles.Add("AB_EBER_[0-9]{13,13}.txt");
    		refFiles.Add("AB_FBER_[0-9]{13,13}.txt");
    		foreach (var pattern in refFiles)
    		{
    			var regex = new Regex(pattern);
    			foreach (var file in files)
    			{
    				if (regex.IsMatch(file))
    				{
    					Console.WriteLine(file);
    				}
    			}
    		}
    	}
    }
