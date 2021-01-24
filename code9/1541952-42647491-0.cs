    string startTime = "3:10 PM";
    string endTime = "4:50 AM";
    TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
    if (duration.TotalMilliseconds<0)
    {
        duration = new TimeSpan(24, 0, 0) + duration;
    }
