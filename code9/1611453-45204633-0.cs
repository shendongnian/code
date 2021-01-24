    static void Main(string[] args)
    {
        DateTime startDate = new DateTime(1988, 4, 1);
        DateTime endDate = new DateTime(2017, 4, 30);
        TimeSpan diff = endDate - startDate;
        Console.WriteLine("Difference in days between two days: " + diff.TotalDays);
        int year = 2000;
        int daysInFeb = DateTime.DaysInMonth(year, 2);
        int daysInYear = DateTime.IsLeapYear(year) ? 366 : 365;
        Console.WriteLine("Days in February " + year + ": " + daysInFeb);
        Console.WriteLine("Days in Year " + year + ": " + daysInYear);
        Console.ReadKey();
        // Outputs:
        // Difference in days between two days: 10621
        // Days in February 2000: 29
        // Days in Year 2000: 366
    }
