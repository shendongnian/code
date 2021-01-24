       private DateTime ComputeNextUtcTimeToRun(long dateTimeStamp, TimeZoneInfo timeZoneInfo)
            {
                try
                {
                    // Get the current time in the target time zone
                    DateTime now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
    
                    // Compute the next local time
                    DateTime scheduledLocalTime = (new DateTime(1970, 1, 1, 0, 0, 0)).AddMilliseconds(dateTimeStamp).ToLocalTime();
    
                    if (scheduledLocalTime < now)
                    {
                        scheduledLocalTime = scheduledLocalTime.AddDays(1);
                    }
                    // If it's invalid, advance.  The clocks shifted forward!
                    if (timeZoneInfo.IsInvalidTime(scheduledLocalTime))
                    {
                        return TimeZoneInfo.ConvertTimeToUtc(scheduledLocalTime.AddHours(1), timeZoneInfo);
                    }
                    // If it's ambiguous, pick the first instance
                    if (timeZoneInfo.IsAmbiguousTime(scheduledLocalTime))
                    {
                        TimeSpan offset = timeZoneInfo.GetAmbiguousTimeOffsets(scheduledLocalTime).Max();
                        DateTimeOffset dto = new DateTimeOffset(scheduledLocalTime, offset);
                        return dto.UtcDateTime;
                    }
                    return TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(scheduledLocalTime, DateTimeKind.Unspecified), timeZoneInfo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
