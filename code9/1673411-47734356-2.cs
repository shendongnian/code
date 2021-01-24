    static bool TryParseAsChar(this string s, out char c)
    {
        if (s != null)
        {
            if (s.Length == 1)
            {
                c = s[0];
                return true;
            }
            if (s.StartsWith("\\u", StringComparison.InvariantCulture) &&
                s.Length == 6)
            {
                var hex = s.Substring(2);
                if (int.TryParse(hex,
                                 NumberStyles.AllowHexSpecifier,
                                 CultureInfo.InvariantCulture,
                                 out var i))
                {
                    c = (char)i;
                    return true;
                }
            }
        }
        c = default(char);
        return false;
    }
