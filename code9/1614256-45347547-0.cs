    private static string RemoveLeadingZeros(this string str)
    {
        int idx = -1;
        if (string.IsNullOrEmpty(str)) return str;
        for (int i = 0; i < str.Length; i++)
        {
            int num = (int)char.GetNumericValue(str[i]);
            if (num == 0) idx = i;
            else break;
        }
        return idx >= 0 ? str.Substring(idx + 1) : str;
    }
