    public static Boolean IsTimeBetween(DateTime refer, DateTime begin, DateTime end, Boolean inclusive = true)
    {
        DateTime from = new DateTime(refer.Year, refer.Month, refer.Day, begin.Hour, begin.Minute, begin.Second, begin.Millisecond);
        DateTime to = new DateTime(refer.Year, refer.Month, refer.Day, end.Hour, end.Minute, end.Second, end.Millisecond);
        if (inclusive)
            return ((from <= refer) && (to >= refer));
        return ((from < refer) && (to > refer));
    }
