    const string PATTERN = @"(?'iframe'<iframe .+(?'link'youtube.com\/embed\/.+?)\")";
    Match match = new Regex(PATTERN, RegexOptions.Multiline).Match(meUrl);
    if(match.Success){
        string link = match.Groups["link"].Value;
        // link is now youtube.com/embed/suEGD8aaSzI?list&playauto=1
        string query = link.Substring(link.LastIndexOf("?") + 1);
        // query is now list&playauto=1
        string[] splittedQuery = quert.Split("&", StringSplitOptions.IgnoreEmptyEntries);
        // splittedQuery is not { "list", "playauto=1" }
        Dictionary<string, string> fullQueryWithValues = new Dictionary<string,string>();
        foreach(string queryFromSplit in splittedQuery){
            KeyValuePair<string, string> queryWithValues = new KeyValuePair<string, string>(queryFromSplit.Split("=", StringSplitOptions.IgnoreEmptyEntries)[0], queryFromSplit.Contains("=") ? queryFromSplit.Split("=", StringSplitOptions.IgnoreEmptyEntries)[1] : string.Empty);
        }
    }
