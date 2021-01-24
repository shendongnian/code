    public string TrimStartIfDigit(this string s)
    {
        int index;
        for (index = 0; index < s.Length; index++)
        {
            if (!char.IsDigit(s[0]))
                break;
        }
        return index == 0 ? s : s.Substring(index); 
    }
