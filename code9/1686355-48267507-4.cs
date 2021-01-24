    foreach (Match match in matches)
    {
        var sb = new StringBuilder();
        sb.Append(match.Groups["exc"].Value).Append("mystring.").Append(match.Groups["word"].Value);
        for (int i = 0; i < match.Groups["op"].Captures.Count; i++)
        {
            sb.Append(' ').Append(match.Groups["op"].Captures[i].Value).Append(' ');
            sb.Append(match.Groups["exc2"].Value).Append("mystring.").Append(match.Groups["word2"].Value);
        }
        Console.WriteLine("Result: {0}", sb.ToString());
    }
