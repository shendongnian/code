    public static class UnixTool {
        public static DateTime Unix2Time(Int64 timeStamp, TimeZoneInfo LocalTimeZone) {
            return TimeZoneInfo.ConvertTimeFromUtc(baseTime.AddSeconds(timeStamp), LocalTimeZone);
        }
    
        public static Int64 Time2Unix(DateTime dateTime, TimeZoneInfo LocalTimeZone) {
            return (Int64)(TimeZoneInfo.ConvertTimeToUtc(dateTime, LocalTimeZone).Subtract(baseTime).TotalSeconds);
        }
    }
