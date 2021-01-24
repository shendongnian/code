    public static DateTime NextDateByDayOfWeek1(DateTime startDate, DayOfWeek dow)
    {
        var daysUntil = ((dow - startDate.DayOfWeek) + 7) % 7;
        return startDate.AddDays(daysUntil);
    }
    
    public static DateTime NextDateByDayOfWeek2(DateTime startDate, DayOfWeek dow)
    {
        var date = startDate;
        while (date.DayOfWeek != dow)
            date = date.AddDays(1);
        return date;
    }
