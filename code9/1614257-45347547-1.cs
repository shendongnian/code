    private static string TrimAndRemoveLeadingZeros(this string str)
    {
        int idx = 0;
        if (string.IsNullOrEmpty(str)) return str;
        str = str.Trim();
        for (int i = 0; i < str.Length; i++)
        {
            int num = (int)char.GetNumericValue(str[i]);
            if (num == 0) idx++;
            else break;
        }
        return str.Substring(idx);
    }
