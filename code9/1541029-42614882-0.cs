    const string TAG_REGEX_PATTERN = @"(?:<{0}>)([^<]+?)(?:<\/{0}>)";
    public static string Parse(string xml, string tag, bool clean, bool replaceNewLines)
    {
        if (xml == String.Empty || tag == String.Empty) { return "error"; }
    
        MatchCollection tagMatches = new Regex(string.Format(TAG_REGEX_PATTERN, tag), RegexOptions.Multiline | RegexOptions.IgnoreCase).Matches(xml);
    
        IList<string> tags = new List<string>();
    
        // Add the tag to a list
        foreach (Match m in tagMatches)
        {
            // Add the tag to the list
            tags.Add(m.Groups[1].Value);
            break; //break as only interested in first result.
        }
    
        string result = tags.Count == 0 ? null : tags[0];
        if (!string.IsNullOrWhiteSpace(result))
        {
            if (clean)
                result = result.Trim();
            if (replaceNewLines)
                result = result.Replace("\r\n", " ");
        }
        else
            result = "error";
        return result;
    }
