        string input = file.Name;
        string input2 = file.Name;
        int indexInterval = input.IndexOf("+");
        int indexDate = input2.IndexOf("_");
        if (indexInterval > 0)
            input = input.Substring(0, indexInterval);
    
        if (indexDate > 0)
            input2 = input2.Substring(indexInterval + 1, input2.Length - indexDate);
    
        string newInterval = input;
        string newDate = input2;
