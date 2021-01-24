    private static void SetDaysInMonth(DateTime mDate)
        {
            int numberOfBusinessDays = Enumerable.Range(1, DateTime.DaysInMonth(mDate.Year, mDate.Month))
                                         .Select(day => new DateTime(2017, mDate.Month, day)) 
                                         .Count(d => d.DayOfWeek != DayOfWeek.Sunday && d.DayOfWeek != DayOfWeek.Saturday); 
        }
