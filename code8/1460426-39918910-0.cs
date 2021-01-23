    public static int HoursUntilDueTime(DateTime time)
    {
        DateTime dueTime = (time + TimeSpan.FromHours(8)).Date + TimeSpan.FromHours(24 + 16);
        return (int)(0.5 + (dueTime - time).TotalHours);
    }
