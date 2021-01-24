    var Test =
    (from F in Directory.EnumerateFiles(SOURCE_FOLDER, SOURCE_EXTENSIONS, SearchOption.AllDirectories)
    let Key = ParenthesisGroupRegex.Replace(F.ToLower(), string.Empty).Trim()
    let Descriptions =
        (from Match Match in ParenthesisGroupRegex.Matches(F.ToLower())
        let CleanedMatches = ParenthesisRegex.Replace(Match.Name, string.Empty)
        let MatchesList = CleanedMatches.Split(',')
        select new Description { Filename = F, Tag = MatchesList.ToList() })
    group Descriptions by Key into DescriptionList)
    .ToDictionary(x=>x.Key,x=>x.Select(y=>y).ToList());
    
