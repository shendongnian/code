    List<string> words = new List<string>() { "c#", "html", "web service", "c#", "c#" };
    Dictionary<string, int> map = new Dictionary<string, int>();
    
    foreach (string w in words)
    {
        if (map.ContainsKey(w))
        {
            map[w] = map[w]+1;
        }
        else
        {
            map[w] = 1;
        }
    }
    
    //to iterate through Dictionary<string, int> use this instead
    foreach (KeyValuePair<string, int> entry in map)
    {
        Console.WriteLine($"{entry.Key}\t{entry.Value}");
    }
