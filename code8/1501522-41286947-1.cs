    public static IEnumerable<DateTime> GetDateRange(DateTime startDate, DateTime endDate)
    {
        var date = startDate.Date;
        while (date <= endDate.Date)
        {
            yield return date;
            date = date.AddDays(1);
        }
    }
