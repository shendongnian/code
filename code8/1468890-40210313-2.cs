    List<string> outputLines=new List<string>();
    foreach (string line in inputLine)
    {
        if(line.IndexOf('=')==-1)
            outputLines.Add(line);
        else
            outputLines.Add(line.Substring(0,line.IndexOf('=')));
    }
