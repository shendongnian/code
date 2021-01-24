    var jsonObj = new JavaScriptSerializer().Deserialize<Dictionary<string, List<Dictionary<string, string>>>>(strP);
    string indent = "   ";
    var sb = new StringBuilder();
    foreach (var outerPair in jsonObj)
    {
        sb.Append(outerPair.Key).AppendLine(":");
        outerPair.Value.SelectMany(d => d).Aggregate(sb, (s, p) => s.Append(indent).Append(p.Key).Append(" - ").AppendLine(p.Value));
    }
    Console.WriteLine(sb);
