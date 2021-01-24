    var sb = new StringBuilder();
    for (int i = 0; i < allLines.Length; i++)
    {
        if (allLines[i].Length > 483)
        {
            sb.Clear();
            sb.Append(allLines[i].Substring(0, 483));
            sb.Append("0");
            sb.Append(allLines[i].Substring(484));
            allLines[i] = sb.ToString();
        }
    }
