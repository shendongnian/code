    var input = @"[952,M] [782,M] [782] {2[373,M]} 
                  [1470] [352] [235] [234] {3[610]}{3[380]} [128] [127]";
    var pattern = @"((:?\{(\d+)(.*?)\})|(:?\[.*?\]))";
    MatchCollection matches = Regex.Matches(input, pattern);
    
    var ls = new List<string>();
    foreach(Match match in matches)
    {
        // check if the item has curly brackets
        // The captures groups will be different if there were curly brackets
        // If there are brackets than the 4th capture group 
        // will have the value of the square brackets and it's content
        if( match.Groups[4].Success ) 
        {
            var value = match.Groups[4].Value;
           
            // The "Count" of the items will 
            // be in the third capture group
            var count = int.Parse(match.Groups[3].Value);
            for(int i=0;i<count;i++)
            {
                ls.Add(value);
            } 
           
        }
        else
        {
            // otherwise we know that square bracket input 
            // is in the first capture group
            ls.Add(match.Groups[1].Value);
        }
    }
