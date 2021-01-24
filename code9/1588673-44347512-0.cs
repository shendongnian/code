    using System;
    using System.Collections.Generic;			
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		string LogInIDs = "124,345,876|765,322,98 |565,99";
    		
    		Console.WriteLine(string.Join("\n", RetrieveAffCodes(LogInIDs, "322")));
    		Console.WriteLine(string.Join("\n", RetrieveAffCodes(LogInIDs, "565")));
    	}
    	
    	public static IEnumerable<string> RetrieveAffCodes(string logInIDs , string logInID)
    	{
    		//We split the list
    		var list = logInIDs.Split('|');
    		//We look for an item with the logInID, if found (?) we split using ',' and then we remove the item
    		var match = list
			    .FirstOrDefault(i => i.Contains(logInID))?
			    .Split(',')
			    .Where(i => i != logInID)
			    .Select(i => i.Trim());
    		if(match != null)
    		{
    			return match;
    		}
    		
    		return new List<string>();
    		
    	}
    }
