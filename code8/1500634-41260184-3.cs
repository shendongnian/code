    static string toCamel(string input)
    {        
        TextInfo info = CultureInfo.CurrentCulture.TextInfo;
        input= info.ToTitleCase(input).Replace("_", string.Empty);
        return input;
    } 
