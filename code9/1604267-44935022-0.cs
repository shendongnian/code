    public static string MsJson(DateTime value)
    {
        long unixEpochTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
        long ticks = (value.ToUniversalTime().Ticks - unixEpochTicks) / 10000;
        if (value.Kind == DateTimeKind.Utc)
        {
            return String.Format("/Date({0})/", ticks);
        }
        else
        {
            TimeSpan ts = TimeZone.CurrentTimeZone.GetUtcOffset(value.ToLocalTime());
            string sign = ts.Ticks < 0 ? "-" : "+";
            int hours = Math.Abs(ts.Hours);
            string hs = (hours < 10) 
                ? "0" + hours 
                : hours.ToString(CultureInfo.InvariantCulture);
            int minutes = Math.Abs(ts.Minutes);
            string ms = (minutes < 10) 
                ? "0" + minutes 
                : minutes.ToString(CultureInfo.InvariantCulture);
            return string.Format("/Date({0}{1}{2}{3})/", ticks, sign, hs, ms);
        }
    }
