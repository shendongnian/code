    /// <summary>
    /// Some informative description
    /// </summary>
    /// <returns>A description of the return value</returns>
    public static string formString(this string value)
    {
        value = value.Replace("\t", " ");
        value = value.Trim();
        return value;
    }
