    private static void FindWeekDays()
    {
        DateTime dateToCheck = new DateTime(2017, 1, 1);
        List<DateTime> dayList = new List<DateTime>();
        while (dateToCheck.Year <= 2017)
        {
            dayList.AddRange(GetWeekDayOfMonth(dateToCheck, DayOfWeek.Saturday));
            dateToCheck = dateToCheck.AddMonths(1);
        }
    
        dayList.ForEach(date => Console.WriteLine(date.ToString()));
    }
