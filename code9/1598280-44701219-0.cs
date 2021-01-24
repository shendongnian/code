    public enum Quaters
    {
        Q1_Start,
        Q1_End,
        Q2_Start,
        Q2_End,
        Q3_Start,
        Q3_End,
        Q4_Start,
        Q4_End
    }
    Dictionary<Quaters, DateTime> dateRange = new Dictionary<Quaters, DateTime>
    {
        {Quaters.Q1_Start, new DateTime(DateTime.Now.Year, 07, 01)},
        {Quaters.Q1_End, new DateTime(DateTime.Now.Year, 09, 15)},
        {Quaters.Q2_Start, new DateTime(DateTime.Now.Year, 10, 01)},
        {Quaters.Q2_End, new DateTime(DateTime.Now.Year, 12, 15)},
        ...
    };
