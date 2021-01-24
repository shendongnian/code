    public static DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
    {
        int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
        return dt.AddDays(-1 * diff).Date;
    }
    static void Main(string[] args)
    {
        DateTime dt = DateTime.Now;
        DateTime sow = StartOfWeek(dt, DayOfWeek.Monday);
        DateTime[] allWeekDays = Enumerable.Range(0, 7).Select(d => sow.AddDays(d)).ToArray();
    }
