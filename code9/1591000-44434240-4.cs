    public List<string> GetIntervals(DateTime startDate, DateTime endDate) {
	    List<string> result = new List<string>();
        result.Add(startDate.ToShortDateString());
        result.Add(endDate.ToShortDateString());
        DateTime target = startDate;
   	    while (target <= endDate) {
    	    result.Add(new DateTime(target.Year, target.Month, DateTime.DaysInMonth(target.Year, target.Month)).ToShortDateString());
	        target = target.AddMonths(1);
   	    }
        result = result.Distinct().ToList();
        result.Sort();
       	return result;
    }
