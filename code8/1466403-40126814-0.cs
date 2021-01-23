    public static bool Contains(this string input, bool caseSensitive, params string[] items)
    {
        input = !caseSensitive ? input.ToLower() : input;
        foreach (var item in items)
        {
            if (input.Contains(!caseSensitive ? item.ToLower() : item))
                return true;
        }
        return false;
    }
