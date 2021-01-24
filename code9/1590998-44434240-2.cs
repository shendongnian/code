    public List<string> GetIntervals(DateTime startDate, DateTime endDate) {
	    List<string> result = new List<string>();
        DateTime target = startDate;
   	    while (target <= endDate) {
            DateTime date = new DateTime(target.Year, +target.Month, DateTime.DaysInMonth(target.Year, target.Month));
    	    if (!result.Contains(date.ToShortDateString())) result.Add(date.ToShortDateString());
	        target = target.AddMonths(1);
   	    }
        if (!result.Contains(startDate.ToShortDateString())) result.Add(startDate.ToShortDateString());
        if (!result.Contains(endDate.ToShortDateString())) result.Add(endDate.ToShortDateString());
        result.Sort();
       	return result;
    }
