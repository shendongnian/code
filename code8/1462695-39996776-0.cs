    private static IEnumerable<DateTime> GetWeekDayOfMonth(DateTime monthToCheck, DayOfWeek weekDayToFind)
    {
        var year = monthToCheck.Year;
        var month = monthToCheck.Month;
        var dayCount = DateTime.DaysInMonth(year, month);
        var daysList = Enumerable.Range(1, dayCount)
                                        .Select(day => new DateTime(year, month, day))
                                        .Where(date => date.DayOfWeek == weekDayToFind)
                                        .ToList<DateTime>();
        // Loop with 2 increment
        int lookupStart = 1;
        int loopCount = 0;
        if (daysList[1].Day <= 9)
        {
            lookupStart = 2;
        }
    
        for (var i = lookupStart; i < daysList.Count(); i = i + 2) 
        {
            if (loopCount < 2)
            {
                yield return daysList[i];
                loopCount++;
            }
        }
    }
