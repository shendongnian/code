    public static string InsertContent(string sentence, string value)
    {
        Regex rgx = new Regex(@"\{[^\}]*\}");
        return rgx.Replace(sentence, value);
    }
