    public static string Test(string str)
    {
        Regex regex = new Regex(@"\d+(ML|KG)\d*");
        Match match = regex.Match(str);
        if (match.Success)
            return match.Value;
        return null;
    }
