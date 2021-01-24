    public static string TrimStart(this string s, Predicate<char> trimIf)
    {
        int index;
        for (index = 0; index < s.Length; index++)
        {
            if (!trimIf(s[index]))
                break;
        }
        return index == 0 ? s : s.Substring(index);
    }
