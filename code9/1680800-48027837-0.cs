    string[] lines = File.ReadAllLines(path);
        
    List<string> aletterlines = new List<string>();
    List<string> CletterLines = new List<string>();
    foreach (var item in lines)
    {
        string[] currentLine = item.Split('|');
        
        if (currentLine[0] == "A")
        {
            aletterlines.Add(item);
        }
        else
        {
            CletterLines.Add(item);
        }
    }
