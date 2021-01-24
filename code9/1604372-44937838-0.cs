    public static IEnumerable<DateTime> GetDates()
    {
        var currentDate = DateTime.Now;
        var numberOfMonthsToShow = 12;
        var dates = new List<DateTime>(numberOfMonthsToShow);
        for (int i = 0; i < numberOfMonthsToShow; i++)
        {
            dates.Add(currentDate);
            currentDate = currentDate.AddMonths(-1);
        }
        return dates;
    }
