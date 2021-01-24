    static public Text GetCategory(string text)
    {
        text = FormatText(text);
        if (Category1.Check(text))
            return new Category1(text);
