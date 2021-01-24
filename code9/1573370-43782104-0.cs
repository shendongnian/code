    var X = new Dictionary<string, List<object>>();
    
    foreach (var a in lst)
    {
        if (!X.Keys.Contains(a))
        {
             X[a].Add(10);
        }
        else
        {
            X.Add(a, new List<object>());
            X[a].Add("hello");
        }
    }
