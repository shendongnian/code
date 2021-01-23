    public static int HoursUntilDueTime(DateTime currentTime, DateTime targetTime)
    {
        DateTime dueTime = (currentTime + TimeSpan.FromHours(24 - targetTime.Hour)).Date + TimeSpan.FromHours(24 + targetTime.Hour);
        return (int)(0.5 + (dueTime - currentTime).TotalHours);
    }
