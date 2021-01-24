    static DateTime GetNextDate(DateTime d1)
    {
        System.Diagnostics.Debug.Assert(d1.Day <= 28, "Behavior not described");
        DateTime d2 = d1.AddDays(28);
        // the following evaluates to 1 for 1-7, 2 for 8-14, etc
        int n1 = (d1.Day - 1) / 7 + 1;
        int n2 = (d2.Day - 1) / 7 + 1;
        if (n2 != n1)
        {
            d2 = d2.AddDays(7);
        }
        return d2;
    }
