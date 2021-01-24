    public static TimeSpan AddTimeSpan(this TimeSpan firstTimeSpan, TimeSpan secondTimeSpan)
    {
        if (firstTimeSpan.TotalMinutes + secondTimeSpan.TotalMinutes > TimeSpan.MaxValue.TotalMinutes)
        {
            return TimeSpan.MaxValue;
        }
        if (firstTimeSpan.TotalMinutes + secondTimeSpan.TotalMinutes < TimeSpan.MinValue.TotalMinutes)
        {
            return TimeSpan.MinValue;
        }
        return firstTimeSpan + secondTimeSpan;
    }
