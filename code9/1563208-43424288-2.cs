    public static string Reverse(this string s)
    {
        if(string.IsNullOrEmpty(s))
        {
            return s;
        }
        var info = new StringInfo(s);
        var sb = new StringBuilder();
        for(int i = info.LengthInTextElements - 1; i > -1 ; i--)
        {
            sb.Append(info.SubstringByTextElements(i, 1));
        }
        return sb.ToString();
    }
