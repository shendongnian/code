    static string FormatString(string str) =>
        RemoveAfter(str, "/*") + SubstringFrom(str, "*/");
    static int IndexOf(string str, string value)
    {
        for (int i = 0; i < str.Length - value.Length; i++)
        {
            bool found = true;
            for (int j = 0; j < value.Length; j++)
            {
                if (str[i + j] != value[j])
                {
                    found = false;
                    break;
                }
            }
            if (found)
            {
                return i;
            }
        }
        return -1;
    }
    static int LastIndexOf(string str, string value)
    {
        for (int i = str.Length - value.Length; i >= 0; i--)
        {
            bool found = true;
            for (int j = 0; j < value.Length; j++)
            {
                if (str[i + j] != value[j])
                {
                    found = false;
                    break;
                }
            }
            if (found)
            {
                return i;
            }
        }
        return -1;
    }
    static string SubstringFrom(string str, string value)
    {
        int startIndex = LastIndexOf(str, value);
        int length = str.Length - startIndex;
        char[] result = new char[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = str[startIndex + i];
        }
        return new string(result);
    }
    static string RemoveAfter(string str, string value)
    {
        int length = IndexOf(str, value) + value.Length;
        char[] result = new char[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = str[i];
        }
        return new string(result);
    }
