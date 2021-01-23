    string pattern = @"personaname"":\s+""(?<name>[^""]+)""";
    string users = webClient.DownloadString("http://pastebin.com/raw/cDHTXXD3");
    Regex regex = new Regex(pattern);
    MatchCollection matches = regex.Matches(users);
    foreach (Match match in matches)
    {
        Console.WriteLine(match.Groups["name"].Value);
    }
