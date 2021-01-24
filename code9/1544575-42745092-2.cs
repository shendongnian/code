    public static CultureInfo DanishCultureInfo = InitCultureInfoWithWeek("da-DK");
    private static CultureInfo InitCultureInfoWithWeek(string name)
    {
        var ci = CultureInfo.GetCultureInfo(name);
        ci = (CultureInfo)ci.Clone();
        ci.DateTimeFormat.FullDateTimePattern = "dddd " + ci.DateTimeFormat.FullDateTimePattern;
        ci = CultureInfo.ReadOnly(ci);
        return ci;
    }
    public static CultureInfo GetCultureForPrinting(string name)
    {
        var ci = CultureInfo.GetCultureInfo(name);
        if (string.Equals(name, "da-DK", StringComparison.InvariantCultureIgnoreCase))
        {
            return DanishCultureInfo;
        }
        else
        {
            return CultureInfo.GetCultureInfo(name);
        }
    }
