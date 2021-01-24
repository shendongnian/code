    static bool TryParseAsChar(this string s, out char c)
    {
        c = default(char);
        if (s.Length == 1)
        {
            c = s[0];
            return true;
        }
        if (!s.StartsWith("\\u") ||
            s.Length != 6)
            return false;
        var hex = s.Substring(2);
        if (int.TryParse(hex,
                         NumberStyles.AllowHexSpecifier,
                         CultureInfo.InvariantCulture,
                         out var i))
        {
            c = (char)i;
            return true;
        }
        return false;
    }
