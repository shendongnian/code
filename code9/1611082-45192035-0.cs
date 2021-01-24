    Dictionary<string, int> items = new Dictionary<string, int>();
    
    foreach(string line in lines)
    {
        var cols = line.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        var operation = cols[2].Trim();
    
        if(items.Keys.Any(x => x.Equals(operation)))
        {
            items[operation]++;
        }
        else
        {
            items[operation] = 1;
        }
    }
