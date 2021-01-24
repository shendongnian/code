    /// <summary> Get working days between two dates (Excluding a list of dates - Holidays) </summary>
    /// <param name="dtmCurrent">Current date time</param>
    /// <param name="dtmFinishDate">Finish date time</param>
    /// <param name="lstExcludedDates">List of dates to exclude (Holidays)</param>
    public static int fwGetWorkingDays(this DateTime dtmCurrent, DateTime dtmFinishDate, List<DateTime> lstExcludedDates)
    {
        Func<DateTime, bool> workDay = currentDate =>
                (
                    currentDate.DayOfWeek == DayOfWeek.Saturday ||
                    currentDate.DayOfWeek == DayOfWeek.Sunday ||
                    lstExcludedDates.Exists(evalDate => evalDate.Date.Equals(currentDate.Date))
                );
    
        return Enumerable.Range(0, 1 + (dtmFinishDate - dtmCurrent).Days).Count(intDay => workDay(dtmCurrent.AddDays(intDay)));
    }
