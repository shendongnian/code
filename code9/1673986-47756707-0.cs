    static public Text GetCategory(string text)
    {
        var formattedText = FormatText(text);
        Text result = null;
        if (Category1.Check(formattedText))
            result = new Category1(formattedText);
        else if (Category2.Check(formattedText))
            result = new Category2(formattedText);
        else if (Category3.Check(formattedText))
            result = new Category3(formattedText);
        if(result != null)
            result.OriginalText = text;
        return result;
    } 
