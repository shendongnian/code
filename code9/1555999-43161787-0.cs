    var s = "Match One 2-1 To Red Team";
    s = "Strongholds on Eden 100-95 Supremacy";
    
    string pattern = @"(\d+)-(\d+)";
    MatchCollection matches = Regex.Matches(s, pattern);
    
    // This will print the number of matches
    Console.WriteLine("{0} matches", matches.Count);
    
    foreach (Match match in matches) {
        GroupCollection data = match.Groups;
        // This will print the number of captured groups in this match
        Console.WriteLine("{0} groups captured in {1}", data.Count, match.Value);
    
        Console.WriteLine("score: " + data[1] + ", score2: " + data[2]);
    
        // Each Group in the collection also has an Index and Length member,
        // which stores where in the input string that the group was found.
        Console.WriteLine("score found at[{0}, {1})", 
            data[1].Index, 
            data[1].Index + data[1].Length);
    }
