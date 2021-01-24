    using System;
	using System.Collections.Generic;
	using System.Linq;
						
	public class Program
	{
		public class Test
		{
			public DateTime Collected {get; set;}
			public DateTime Staged {get; set;}
			public DateTime Processed {get; set;}
		}
		
		public static void Main()
		{
			List<Test> queryResults = new List<Test>();
			
			queryResults.Add(new Test(){Collected=Convert.ToDateTime("1/20/2017"),Staged=Convert.ToDateTime("2/19/2017"),Processed=Convert.ToDateTime("3/17/2016")});
			queryResults.Add(new Test(){Collected=Convert.ToDateTime("4/21/2017"),Staged=Convert.ToDateTime("6/18/2014"),Processed=Convert.ToDateTime("12/15/2015")});
			
			var collectedDate = queryResults.Min(d => d.Collected);
			var stagedDate = queryResults.Min(d => d.Staged);
			var ProcessedDate = queryResults.Min(d => d.Processed);
			
			List<DateTime> listDate = new List<DateTime>(){collectedDate,stagedDate,ProcessedDate};
			
			Console.WriteLine(listDate.Min(d => d));
			
            //2nd Solution
            //Compare DateTime between column and then rows to get min value
			Console.WriteLine(queryResults.Min(d => getMin(getMin(d.Collected, d.Staged), d.Processed)));
		}
		
        //Function to compare two DateTime
		public static DateTime getMin(DateTime a, DateTime b)
		{
			return a < b ? a : b;
		}
	}
