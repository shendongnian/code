    public static DateTime NextDateByDayOfWeek1(DayOfWeek dow)
    {
        var daysUntil = ((dow - DateTime.Today.DayOfWeek) + 7) % 7;
        return DateTime.Today.AddDays(daysUntil);
    }
    
    public static DateTime NextDateByDayOfWeek2(DayOfWeek dow)
    {
        var date = DateTime.Today;
        while (date.DayOfWeek != dow)
            date = date.AddDays(1);
        return date;
    }
