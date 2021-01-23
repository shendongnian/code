    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;
    
    public class TestSortDateStrings
    {
    	public static void Main()
    	{
    		var monthList = new List<string> {"Apr-2016", "Aug-2015", "Nov-2015", "Oct-2015", "Sep-2015", "Jul-2016"};
    		var sortedMonths = monthList
                .Select(x => new { month = x, Sort = DateTime.ParseExact(x, "MMM-yyyy", CultureInfo.InvariantCulture) })
                .OrderByDescending(x => x.Sort)
                .Select(x => x.month)
                .ToList();
    		
    		foreach(var m in sortedMonths)
    		{
    			Console.WriteLine(m);
    		}
    	}
    }
