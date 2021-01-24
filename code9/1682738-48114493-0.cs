    public static DateTime GetNearestEOM(DateTime date)
    {
        DateTime EOMPrev = new DateTime(date.Year, date.Month, 1).AddDays(-1);
        DateTime EOMNext = new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
        DateTime NearestEOM = (date - EOMPrev).TotalDays < (EOMNext - date).TotalDays ? EOMPrev : EOMNext;
        return NearestEOM;
    }
    GetNearestEOM(new DateTime(2017, 3, 4));  // 2017-02-28 00:00:00
    GetNearestEOM(new DateTime(2017, 3, 20)); // 2017-03-31 00:00:00
