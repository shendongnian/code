    var activities = ...;
    TimeZoneInfo userZone = TimeZoneInfo.FindSystemTimeZoneById(user.TimeZoneId);
    foreach (var thisActivity in activities)
    {
        DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc( thisActivity.ActivityTime, userZone);
        thisActivity.ActivityTime = localTime;
    }
   
   
    
