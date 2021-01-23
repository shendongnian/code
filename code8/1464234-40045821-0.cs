    internal static string GetMMMYYFromYYYYMM(String YYYYMMVal)
    {
        DateTime intermediateDate = DateTime.ParseExact(YYYYMMVal, "yyyyMM", CultureInfo.InvariantCulture);
        return intermediateDate.ToString("MMMyy");
    }
