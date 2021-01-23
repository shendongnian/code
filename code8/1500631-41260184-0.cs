    static string toCamel(string input)
    {
        var str = input.ToLower().Replace("_", " ");
        TextInfo info = CultureInfo.CurrentCulture.TextInfo;
        str = info.ToTitleCase(str).Replace(" ", string.Empty);
        return str;
    } 
   
