    List<string> labels = new List<string>();
    Regex regex = new Regex(@"\r\n(BRD1|MAT2|INFO4),([^(,|\r\n)]*,?[^(,|\r\n)]*)");
    using (var file = new System.IO.StreamReader(e.FullPath))
    {
        foreach (Match match in regex.Matches(file.ReadToEnd()))
        {
            labels.Add(match.Groups[2].Value);
        }
    }
