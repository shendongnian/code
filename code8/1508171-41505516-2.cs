    /// <summary>
    /// This function calculates the next datetime interval for a given datetime, based on a scheduled time.
    /// Eg. Job is scheduled to run at 15:00 and every 5 minutes, the next scheduled time will be 15.05, then 15.10 and so forth.
    /// The calculated time will always be after the "afterDateTime".
    /// </summary>
    /// <param name="baseDatetime">The time that scheduled time is based on</param>
    /// <param name="interval">The interval in minutes</param>
    /// <param name="afterDateTime">Usually datetime now, but the date it should be "after".</param>
    /// <param name="tickPrecision">[Optional (Default = TimeSpan.TicksPerSecond)] Determine the tick precision, the lowest possible value is TicksPerMillisecond</param>
    /// <returns>The next scheduled time</returns>
    public static DateTime CalculateNextScheduledTime(DateTime baseDatetime, int interval, DateTime afterDateTime, long tickPrecision = TimeSpan.TicksPerSecond)
    {
        // Reset afterDateTime to seconds
        afterDateTime = new DateTime(((long)afterDateTime.Ticks / tickPrecision) * tickPrecision);
        // (Subtract Difference in modulus time intervals between aftertime base time) + the interval.
        return afterDateTime - TimeSpan.FromMinutes((afterDateTime - baseDatetime).TotalMinutes % interval) + TimeSpan.FromMinutes(interval);
    }
