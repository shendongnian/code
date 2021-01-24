      List<string> list = new List<string>();
    string sample = "where dog is and cat is and bird is";
    MatchCollection matches = Regex.Matches(sample, @"\w+ is");
    foreach (Match m in matches)
    {
        list.Add(m.Value.ToString());
    }
