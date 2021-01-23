    public static DateTime? ParseTimeSpan(this string toParse, IFormatProvider formatProvider)
    {
        DateTime value;
        if (DateTime.TryParse(toParse, formatProvider, DateTimeStyles.None, out value))
        {
            return value;
        }
        return null;
    }
