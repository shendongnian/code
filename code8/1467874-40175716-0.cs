     public static class DateTimeExtensions
        {
            public static DateTime As(this DateTime source, string timeZoneName)
            {
                DateTime utcTime = DateTime.SpecifyKind(source, DateTimeKind.Unspecified);
                TimeZoneInfo newTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName);
                return TimeZoneInfo.ConvertTimeFromUtc(utcTime, newTimeZone);
            }
        }
