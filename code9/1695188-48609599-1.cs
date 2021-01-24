    static DateTime GetNextDate(DateTime d1) {
        DateTime d2 = d1.AddDays(35);
        // the following evaluates to 1 for 1-7, 2 for 8-14, etc
        int n1 = (d1.Day - 1) / 7 + 1;
        int n2 = (d2.Day - 1) / 7 + 1;
        // what happens to 29, 30 and 31 is not described in OP
        System.Diagnostics.Debug.Assert(n1 < 5); 
        if (n2 > n1)
        {
            d2 = d2.AddDays(-7);
        }
        return d2;
    }
