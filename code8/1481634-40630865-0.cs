    public void ProcessSpans(string inputHTML)
    {
        string pattern = @"<span([^>]*)class=\""(\w+)\""([^>]*)>(.*)<\/span>";
        RegexOptions regexOptions = RegexOptions.Multiline;
        Regex regex = new Regex(pattern, regexOptions);
        var matches = regex.Matches(inputHTML);
        //Process the matches with your logic. 
    }
