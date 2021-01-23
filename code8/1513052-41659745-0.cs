    string fixedText = ReplaceSingleQuote("L'df'ds");
    public static ReplaceSingleQuote(string text)
    {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            return text.Replace("'", "&apos;");
    }
