    public static void DateTimeDiff(DateTime startDate, DateTime endDate, out int years, out int months, out int days)
    {
        years = 0;
        months = 0;
        days = 0;
        while (startDate.AddYears(1) < endDate)
        {
            startDate = startDate.AddYears(1);
            years++;
        }
        while (startDate.AddMonths(1) < endDate)
        {
            startDate = startDate.AddMonths(1);
            months++;
        }
        while (startDate.AddDays(1) < endDate)
        {
            startDate = startDate.AddDays(1);
            days++;
        }
    }
