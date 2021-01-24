    Dictionary<string, string> fields = new Dictionary<string, string>();
    List<string> contents = new List<string>();
    
    foreach (var word in main.Split(' '))     //main is a string, e.g. "Type:Non-Fiction Murder Non ISBN:000000001 Kill"
    {
        var splitted = word.Split(':');
        if (splitted.Length == 2)
        {
            fields.Add(splitted[0], splitted[1]);
            continue;
        }
        contents.Add(word);
    }
