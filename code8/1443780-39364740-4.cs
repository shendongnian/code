    public DateTime CalculateFutureDate(DateTime fromDate, int numberofWorkDays,
                                         List<DateTime> holidays)
    {
        var futureDate = fromDate;
        while (numberofWorkDays != 0)
        {
            if (!isHoliday(futureDate, holidays))
                numberofWorkDays--;
            futureDate = futureDate.AddDays(1);
        }
        while (isHoliday(futureDate, holidays))
            futureDate = futureDate.AddDays(1);
        return futureDate;
    }
    bool isHoliday(DateTime testDate, List<DateTime>holidays)
    {
        return (testDate.DayOfWeek == DayOfWeek.Sunday
               || (holidays != null && holidays.Contains(testDate)));
    }
