    public static DateTime? TryGetDateTime(this string str, IFormatProvider provider, string format = null)
    {
        DateTime dt;
        bool valid = format == null 
            ? DateTime.TryParse(str, provider, DateTimeStyles.None, out dt) 
            : DateTime.TryParseExact(str, format, provider, DateTimeStyles.None, out dt);
        if (valid)
            return dt;
        else
            return null;
    }
