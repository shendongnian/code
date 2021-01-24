    if (!String.IsNullOrWhiteSpace(File1Lines[lineNo]) && 
        !String.IsNullOrWhiteSpace(File2Lines[lineNo]))
    {
        if (String.Compare(File1Lines[lineNo], File2Lines[lineNo]) != 0)
        {
            NewLines.Add("FROM File2. Line " + lineNo + ": " + File2Lines[lineNo]);
            continue;
        }
    }
    else if (!String.IsNullOrWhiteSpace(File1Lines[lineNo])) 
    {
        NewLines.Add("FROM File1. Line " + lineNo + ": " + File2Lines[lineNo]);
        continue;
    }
    else if (!String.IsNullOrWhiteSpace(File2Lines[lineNo])) 
    {
        NewLines.Add("FROM File2. Line " + lineNo + ": " + File2Lines[lineNo]);
        continue;
    }
