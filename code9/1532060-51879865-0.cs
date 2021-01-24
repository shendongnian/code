    public static string ToCamelCase(this string text)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(te);
    }
    public static string ToCamelCase(this string text)
    {
        return String.Join(" ", text.Split()
        .Select(i => Char.ToUpper(i[0]) + i.Substring(1)));}
    public static string ToCamelCase(this string text) {
      char[] a = text.ToLower().ToCharArray();
        for (int i = 0; i < a.Count(); i++ )
        {
            a[i] = i == 0 || a[i-1] == ' ' ? char.ToUpper(a[i]) : a[i];
        }
        return new string(a);}
