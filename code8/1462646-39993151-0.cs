     internal static DateTime ConvertTimeToUtc(DateTime dateTime, TimeZoneInfoOptions flags)
    {
        if (dateTime.Kind == DateTimeKind.Utc)
        {
            return dateTime;
        }
        CachedData cachedData = s_cachedData;
        return ConvertTime(dateTime, cachedData.Local, cachedData.Utc, flags, cachedData);
    }
