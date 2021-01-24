    // Get number that corresponds to the month that is n months after the current one
    static int GetMonth(int offset, int cMonth)
    {
        int s = cMonth + offset;
        return s > 12 ? s - 12 : s;
    }
    // Get the year containing the month that is n months after the current one
    static int GetYear(int offset, int cMonth, int cYear)
    {
        int month = GetMonth(offset, cMonth);
        return month >= cMonth ? cYear : cYear + 1;
    }
    // Get the number of days in the month that is n months after the current one
    static int GetMonthDays(int offset, int cMonth, int cYear)
    {
        return DateTime.DaysInMonth(GetYear(offset, cMonth, cYear), GetMonth(offset, cMonth));
    }
    // Get a DateTime which represents the next time a day of number $day comes up in the calendar
    static DateTime GetNextDate(int day, bool includeCurrentDay)
    {
        // Get current date ONCE in the code to ensure consistency
        var cDate = DateTime.Now;
        int cDay = cDate.Day;
        int cMonth = cDate.Month;
        int cYear = cDate.Year;
        // Make sure provided day is valid
        if (day > 0 && day <= 31)
        {
            // Important stuff here
            int offset = includeCurrentDay ? day > currentDay ? 0 : 1 : day >= currentDay ? 0 : 1;
            // Shouldn't repeat more than 3 times max
            while (true)
                {
                    if (GetMonthDays(offset, cMonth, cYear) >= day)
                {
                    break;
                }
                offset++;
            }
            return new DateTime(GetYear(offset, cMonth, cYear), GetMonth(offset, cMonth), day);
        }
        // Day provided wasn't a valid one
        throw new ArgumentOutOfRangeException("day", "Day isn't valid");
    }
