    static DateTime GetNextDate(this DateTime cDate, int day)
    {
        // Make sure provided day is valid
        if (day > 0 && day <= 31)
        {
            while (true)
            {
                // See if day has passed in current month or is not contained in it at all
                if (day > cDate.Day && day <= DateTime.DaysInMonth(cDate.Year, cDate.Month))
                {
                    // If so, break and return
                    break;
                }
                // Advance month by one and set day to one
                cDate = cDate.AddMonths(1).AddDays(1 - cDate.Day);
            }
            // Return if the cDate's month contains day and it hasn't passed
            return new DateTime(cDate.Year, cDate.Month, day);
        }
        // Day provided wasn't a valid one
        throw new ArgumentOutOfRangeException("day", "Day isn't valid");
    }
