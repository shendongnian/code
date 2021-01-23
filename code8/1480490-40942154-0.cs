        public static DateTime? As(this DateTime? dt, TimeZoneInfo targetTimeZone)
        {
            if (dt.HasValue)
                return dt.Value.As(targetTimeZone);
            else
                return dt;
        }
        public static DateTime As(this DateTime dt, TimeZoneInfo targetTimeZone)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(dt, targetTimeZone);
        }
