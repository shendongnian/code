    public static string TrimTo(this string value, int maxLength)
    {
        if (value == null || value.Length <= maxLength)
           return value;
    
        return value.Substring(0, maxLength);
    }
