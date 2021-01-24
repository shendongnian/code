    List<string> results = new List<string>();
    foreach(string line in input.Split('\n'))
    {
        string current = line + ";";
        int start = 0;
        while(current.Length - start > maxLength)
        {
            int splitAt  = current.LastIndexOf(" ", start, maxLength);
            if(splitAt == -1)
                splitAt = start + maxLength;
            results.Add(current.Substring(start, splitAt - start);
            start = splitAt;            
        }
        if(start < current.Length)
            results.Add(current.Substring(start));
    }
