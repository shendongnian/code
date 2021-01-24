    public static DateTime AddMonths(DateTime val, double months)
    {
        // expand out the number of days in a month to a wider value than 30.4167
        const double daysInMonth = 30.41666667;
        
        double days = months * daysInMonth;
        // could also just use val.AddDays(days);
        TimeSpan ts = TimeSpan.FromDays(days);
        DateTime dt = val + ts;
        
        return dt;
    }
