    public static ulong ToJavascriptTicks(this DateTime t)
    {
        return (ulong)(t.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds;
    }
    public static DateTime FromJavascriptTicks(this DateTime t, ulong ticks)
    {
        return new DateTime(0, DateTimeKind.Utc).AddMilliseconds(ticks).Add(new DateTime(1970, 1, 1) - DateTime.MinValue).ToLocalTime();
    }
