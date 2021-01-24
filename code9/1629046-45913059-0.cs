    public static int IndexOf(this IList<string> list, string value, StringComparer comparer)
    {
        return list.FindIndex(i => comparer.Equals(i, value));
    }
    public static int CaseInsensitiveIndexOf(this IList<string> list, string value)
    {
        return IndexOf(list, value, StringComparer.CurrentCultureIgnoreCase);
    }
    public static string CaseInsensitiveFind(this IList<string> list, string value)
    {
        return list.Find(i => StringComparer.CurrentCultureIgnoreCase.Equals(i, value));
    }
