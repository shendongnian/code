    public static string Do(string myString)
    {
        var sb = new StringBuilder();
        var open = false;
        var digits = new HashSet<char>{'0', '1', '2','3','4','5','6','7','8','9'};
        foreach(var c in myString)
        {
            if (digits.Contains(c))
            {
                if (!open)
                {
                    sb.Append("<");
                    open = true;
                }
            }
            else
            {
                if (open)
                {
                    open = false;
                    sb.Append(">");
                }
            }
            sb.Append(c);
        }
        if (open)
        {
            sb.Append(">");
        }
        return sb.ToString();
    }
