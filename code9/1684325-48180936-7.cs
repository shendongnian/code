    public static string Reverse(this string source)
    {
        if (string.IsNullOrEmpty(source))
        {
            return source;
        }
        var info = new StringInfo(source);
        var sb = new StringBuilder();
        for (int i = info.LengthInTextElements - 1; i > -1; i--)
        {
            sb.Append(info.SubstringByTextElements(i, 1));
        }
        return sb.ToString();
    }
