    string startTime = "3:10 PM";
    string endTime = "4:50 AM";
    TimeSpan duration = DateTime.Parse(endTime) - DateTime.Parse(startTime);
    if (duration < TimeSpan.Zero)
    {
        duration += TimeSpan.FromDays(1);
    }
