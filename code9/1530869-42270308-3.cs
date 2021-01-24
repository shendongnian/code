    public static class Extensions
    {
        public static DateTime AddMonths(this DateTime date, decimal months)
        {
            int m = (int)months;
            var ret = date.AddMonths(m);
            var start = new DateTime(ret.Year, ret.Month, 1);
            var end = start.AddMonths(1).AddDays(-1);
           return ret.AddDays(((end.AddDays(1) - start).TotalDays + 1) * (double)(months - m));
        }
    }
