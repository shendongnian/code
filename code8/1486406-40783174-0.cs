    public static string TrimAllWithSplitAndJoin(string str)
    {
        return string.Concat(str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
    }
    
    static Regex whitespace = new Regex(@"\s+", RegexOptions.Compiled);
    public static string TrimAllWithRegex(string str)
    {
        return whitespace.Replace(str, "");
    }
    foreach (DataColumn col in cloned.Columns)
    {
        col.ColumnName = TrimAllWithSplitAndJoin(col.ColumnName);
    }
