    string rtfText = File.ReadAllText(path);
    List<string> loStringList = new List<string>();
    StringBuilder loBuilder = null;
    
    foreach (var lsLine in Regex.Split(rtfText, Environment.NewLine))
    {
        if (lsLine.StartsWith("!##"))
        {
            if (loBuilder != null)
                loStringList.Add(loBuilder.ToString());
            loBuilder = new StringBuilder();
        }
        else if (loBuilder != null)
            loBuilder.AppendLine(lsLine);
    }
    
    if (loBuilder != null)
        loStringList.Add(loBuilder.ToString());
