		DateTime start = new DateTime(2017,10,05);
		DateTime end = new DateTime(2018,2,20);
		DateTime current = start;
		
		Console.WriteLine(start.ToShortDateString());
		int startLastDay = DateTime.DaysInMonth(start.Year, start.Month);
		if(startLastDay != start.Day)
			Console.WriteLine(new DateTime(start.Year, start.Month, startLastDay).ToShortDateString());
		
		
		while(current < end)
		{
			current = current.AddMonths(1);
			if(current > end)
				Console.WriteLine(end.ToShortDateString());
			
			int lastDay = DateTime.DaysInMonth(current.Year, current.Month);
			current = new DateTime(current.Year, current.Month, lastDay);
			Console.WriteLine(current.ToShortDateString());
		}
