    var input = @"[952,M] [782,M] [782] {2[373,M]} 
                  [1470] [352] [235] [234] {3[610]}{3[380]} [128] [127]";
    var pattern = @"((:?\{(\d+)(.*?)\})|(:?\[.*?\]))";
    MatchCollection matches = Regex.Matches(input, pattern);
    
    var ls = new List<string>();
    foreach(Match match in matches)
    {
        //check if the item has curly brackets
        // if it did then the capture groups will be different
        if( match.Groups[4].Success ) 
        {
            var value = match.Groups[4].Value;
           
            //now parse the value in the curly braces
            var count = int.Parse(match.Groups[3].Value);
            for(int i=0;i<count;i++)
            {
                ls.Add(value);
            } 
           
        }
        else
        {
            //otherwise we know that square bracket input is in capture group one
            ls.Add(match.Groups[1].Value);
        }
    }
