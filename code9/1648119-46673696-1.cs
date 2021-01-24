    public static void DateTimeDiff(DateTime dt1, DateTime dt2, out int years, out int months, out int days)
    {
        DateTime start = dt1 < dt2 ? dt1 : dt2;
        DateTime end = dt2 > dt1 ? dt2 : dt1;
        years = 0;
        months = 0;
        days = 0;
        while (start.AddYears(1) < end)
        {
            start = start.AddYears(1);
            years++;
        }
        while (start.AddMonths(1) < end)
        {
            start = start.AddMonths(1);
            months++;
        }
        while (start.AddDays(1) < end)
        {
            start = start.AddDays(1);
            days++;
        }
    }
