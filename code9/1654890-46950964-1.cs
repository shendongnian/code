    String[] lines = File.ReadAllLines(@"songs.txt");
    List<Plays> plays = new List<Plays>();
    foreach (string line in lines)
    {
        var matches = Regex.Match(line, @"^(\d+)\s(\d+)\s(\d+)\s(.+)\:(.+)$"); //this will split your line into groups
        if (matches.Success)
        {
            Plays play = new Plays();
            play.RadioID = int.Parse(matches.Groups[1].Value);
            play.PlayTimeMinutes = int.Parse(matches.Groups[2].Value);
            play.PlayTimeSeconds = int.Parse(matches.Groups[3].Value);
            play.Performer = matches.Groups[4].Value;
            play.Song = matches.Groups[5].Value;
            plays.Add(play);
        }
    }
