    void Main()
    {
    	SortDaysOfWeek(new[] {
    		"Monday",
    		"Wednesday",
    		"Tuesday",
    		"Thursday",
    		"Sunday"
    	}).Dump();
    }
    
    // Define other methods and classes here
    
    DayOfWeek GetDayOfWeekFromString(string str)
    {
    	return (DayOfWeek)Enum.Parse(typeof(DayOfWeek), str);
    }
    
    int GetDayOfWeekPosition(DayOfWeek dow)
    {
    	return (int)dow;
    }
    
    List<string> SortDaysOfWeek(IEnumerable<string> daysOfWeek)
    {
    	return daysOfWeek
    		.Select(GetDayOfWeekFromString)
    		.GroupBy(x => GetDayOfWeekPosition(x), x => x)
    		.OrderBy(g => g.Key)
    		.SelectMany(x => x)
    		.Select(dow => dow.ToString())
    		.ToList();
    }
