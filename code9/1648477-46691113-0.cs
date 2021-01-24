    string pat = @"@([a-z]+)";
    string src = "Hello my name is @Naveh and my friend is named @Amit";
    string output = "";
    // Instantiate the regular expression object.
    Regex r = new Regex(pat, RegexOptions.IgnoreCase);
    // Match the regular expression pattern against a text string.
    Match m = r.Match(src);
    while (m.Success)
    {
        string matchValue = m.Groups[1].Value; //m.Groups[0] = "@Name". m.Groups[1] = "Name"
        output += "Match: " + matchValue + "\r\n";
        m = m.NextMatch();
    }
    Console.WriteLine(output);
    Console.ReadLine();
