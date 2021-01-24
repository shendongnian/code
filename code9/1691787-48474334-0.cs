    string Example()
    { 
        var matched = cardSetWithWordCounts.Where(x => x.IsToggled).Take(2).ToList();
    
        switch (matched.Count)
        {
            case 0: return null;
            case 1: return matched[0].Name;
            default: return "mixed";
        }
    }
 
     
