    public static IEnumerable<DateRange> Convert(IEnumerable<DateTime> dates)
    {
        var ret = new DateRange();
        foreach (var date in dates)
        {
            if (ret.PeriodEnd == default(DateTime))
            {
                ret.PeriodStart = date;
                ret.PeriodEnd = date;
            }
            else if (ret.PeriodEnd.AddDays(1) == date)
            {
                ret.PeriodEnd = date;
            }
            else
            {
                yield return ret;
                ret = new DateRange();
            }
            }
         yield return ret;
     }
