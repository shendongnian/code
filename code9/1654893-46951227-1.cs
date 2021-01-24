    var pattern=@"^(\d+)\s(\d+)\s(\d+)\s(.+)\:(.+)$";
    var regex=new Regex(pattern);
    var plays = from line in File.ReadLines(filePath)
                let matches=regex.Match(line)
                select new Plays {
                              RadioID = int.Parse(matches.Groups[1].Value),
                              PlayTimeMinutes = int.Parse(matches.Groups[2].Value),
                              PlayTimeSeconds = int.Parse(matches.Groups[3].Value),
                              Performer = matches.Groups[4].Value,
                              Song = matches.Groups[5].Value 
                           };
