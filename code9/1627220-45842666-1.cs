    Dictionary<string, string> newList = new Dictionary<string, string>();
    
    foreach (string s in fn)
    if (!newList.ContainsKey(s))
    {
         newList.Add(s, s);
    }
