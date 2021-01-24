    // Get a DateTime which represents the next time a day of number $day comes up in the calendar
    static DateTime GetNextDate(this DateTime cDate, int day)
    {
        // Make sure provided day is valid
        if (day > 0 && day <= 31)
        {
            // See if day has passed in current month or is not contained in it at all
            if (day < cDate.Day || day > DateTime.DaysInMonth(cDate.Year, cDate.Month))
            {
                // Call method again but one month ahead, with the day set to 1
                return GetNextDate(cDate.AddMonths(1).AddDays(1 - cDate.Day), day);
            }
            // Return if the cDate's month contains day and it hasn't passed
            return new DateTime(cDate.Year, cDate.Month, day);
        }
        // Day provided wasn't a valid one
        throw new ArgumentOutOfRangeException("day", "Day isn't valid");
    }
