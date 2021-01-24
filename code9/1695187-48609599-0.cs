    static DateTime GetNextDate(DateTime d1) {
        DateTime d2 = d1.AddDays(35);
        int n1 = (d1.Day - 1) / 7 + 1; // evaluates to 1 for 1-7, 2 for 8-14, ...
        int n2 = (d2.Day - 1) / 7 + 1;
        System.Diagnostics.Debug.Assert(n1 < 5);
        if (n2 > n1)
        {
            d2 = d2.AddDays(-7);
        }
        return d2;
    }
