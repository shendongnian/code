    public List<string> GetIntervals(DateTime startDate, DateTime endDate) {
	    List<string> result = new List<string>() {
		    startDate.Year + "-" + startDate.Month.ToString("D2") + "-" + startDate.Day.ToString("D2"),
		    endDate.Year + "-" + endDate.Month.ToString("D2") + "-" + endDate.Day.ToString("D2")
	    };
        DateTime target = startDate;
   	    while (target <= endDate) {
            string date = target.Year + "-" + target.Month.ToString("D2") + "-" + DateTime.DaysInMonth(target.Year, target.Month).ToString("D2");
    	    if (!result.Contains(date)) result.Add(date);
	        target = target.AddMonths(1);
   	    }
        result.Sort();
       	return result;
    }
