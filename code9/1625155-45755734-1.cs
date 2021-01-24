    public static DateTime NextDateByDayOfWeek1(DayOfWeek dow)
    {
        var daysUntil = ((dow - DateTime.Today.AddDays(1).DayOfWeek) + 7) % 7;
        return DateTime.Today.AddDays(1 + daysUntil);
    }
    
    public static DateTime NextDateByDayOfWeek2(DayOfWeek dow)
    {
        var date = DateTime.Today.AddDays(1);
        while (date.DayOfWeek != dow)
            date = date.AddDays(1);
        return date;
    }
