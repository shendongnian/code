    for(int i = 0; i < allLines.Length; i++)
    {
        if (allLines[i].Length > 483)
        {
            allLines[i] = allLines[i].Substring(0, 483) + "0" + lines[i].Substring(484);
        }
    }
