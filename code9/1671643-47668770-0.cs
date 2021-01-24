    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        List<DateTime> dates = new List<DateTime>();
        for(int i = 1; i <= 50; i++)
        {
            DateTime date = DateTime.Now.AddDays(i);
            dates.Add(date);
            Trace.WriteLine(date.ToString("dd.MM.yyyy HH:mm:ss dddd"));
        }
        List<DateTime> filteredDates = dates.Where(date => 
                                                   !(date.DayOfWeek == DayOfWeek.Saturday ||
                                                     date.DayOfWeek == DayOfWeek.Sunday))
                                            .ToList();
        Trace.WriteLine("------NO-WEEKENDS----------");
        filteredDates.ForEach(date => Trace.WriteLine(date.ToString("dd.MM.yyyy HH:mm:ss dddd")));
        Console.ReadKey();
    }
