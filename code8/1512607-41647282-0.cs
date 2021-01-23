    public static Period GetNextPeriod(this Period period)
    {
        return new Period(period.EndDate);
    }
    public static MonthlyPeriod GetNextPeriod(this MonthlyPeriod period)
    {
        return new MonthlyPeriod(period.EndDate);
    } 
