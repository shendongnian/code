    using System;
    using System.Linq;
    using System.Globalization;
    
    public class Program
    {
    	// **Solution 1:** 
        // Take your string, parse it into DateTime, print is as you like:
    	public static string DateParser(string d)
    	{
    		string[] possibleFormats = new[]{"MM/dd/yyyy", "MM/d/yyyy", "M/dd/yyyy", "M/d/yyyy"};
    		 
    		DateTime parsedDate;
    		
    		// try each possible format
    		foreach (var format in possibleFormats)
    		{
    			if (DateTime.TryParseExact(d, format, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
    			{
    				return parsedDate.ToString("MM-dd-yyyy");
    			}
    		}
    		// this will happen if the input is malformed
    		return null;
    	}
    	
    	// **Solution 2:**  
        // for your special case this will simply replace the `/` by `-`  
        // all the numbers are already in the correct locations...      
    	public static string DateStringFixer(string d) {return d.Replace('/','-'); }
    
    
