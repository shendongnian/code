    public static DateTime FirstMonday(int year)
    {
        var firstDay = new DateTime(year, 1, 1);
            
        return new DateTime(year, 1, (8 - (int)firstDay.DayOfWeek) % 7 + 1);
    }
