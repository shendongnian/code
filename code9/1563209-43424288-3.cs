    public static string Capitalize(this string s)
    {
        if(string.IsNullOrEmpty(s))
        {
            return s;
        }
        var charArray = s.ToLower().ToCharArray();
        charArray[0] = Char.ToUpper(charArray[0]);
        return new string(charArray);
    }
