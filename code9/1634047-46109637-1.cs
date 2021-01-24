    TimeSpan start = TimeSpan.Parse("20:00:00");
    TimeSpan end = TimeSpan.Parse("08:00:00");
    TimeSpan now = DateTime.Now.TimeOfDay;
                
    if (now.IsBetween(start, end))
    {
         Console.WriteLine("Between 20 to 8");
    }
    else
    {
         Console.WriteLine("Not Between 20 and 8");
    }
    
    Console.WriteLine("Time remaining before 8 AM is: {0} Hrs.", 
    (now.Hours > start.Hours) ? TimeSpan.Parse("24:00:00").Subtract(now).Add(end).Hours : 
    end.Subtract(now).Hours); //TimeSpan.Parse("24:00:00") is to compensate midnight hours.
 
    public static class Extensions
    {
            public static bool IsBetween(this TimeSpan timeNow, TimeSpan start, TimeSpan end)
            {
                var time = timeNow;
                // If the start time and the end time is in the same day.
                if (start <= end)
                    return time >= start && time <= end;
                // The start time and end time is on different days.
                return time >= start || time <= end;
            }
    }
