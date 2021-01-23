    Regex stringAndCommentRegex = new Regex(@"(?<string>'[^\\']*...");
    MatchCollection matches = stringAndCommentRegex.Matches(text);
    foreach (Match match in matches)
    {
        GroupCollection groups = match.Groups;
        if (match.groups["string"].Value.Length > 0)
        {
            // handle string
        }
        else if (match.groups["comment"].Value.Length > 0)
        {
            // handle comment
        }
    }
    
