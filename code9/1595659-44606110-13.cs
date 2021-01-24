    static DateTime GetNextDate3(this DateTime cDate, int day, bool includeToday = false)
    {
        // Make sure provided day is valid
        if (day > 0 && day <= 31)
        {
            while (true)
            {
                // See if day has passed in current month or is not contained in it at all
                if ((includeToday && day > cDate.Day || (includeToday && day >= cDate.Day)) && day <= DateTime.DaysInMonth(cDate.Year, cDate.Month))
                {
                    // If so, break and return
                    break;
                }
                // Advance month by one and set day to one
                // FIXED BUG HERE (note the order of the two calls)
                cDate = cDate.AddDays(1 - cDate.Day).AddMonths(1);
                // Set includeToday to true so that the first of every month is taken into account
                includeToday = true;
            }
            // Return if the cDate's month contains day and it hasn't passed
            return new DateTime(cDate.Year, cDate.Month, day);
        }
        // Day provided wasn't a valid one
        throw new ArgumentOutOfRangeException("day", "Day isn't valid");
    }
