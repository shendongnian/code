    int weekendDays = 0;
    
    for(DateTime date = startDate; date.Date <= endDate.Date; date = date.AddDays(1))
    {
        if ((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday))
    	{
    		weekendDays++;
    	}
    }
