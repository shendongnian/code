    var l = new List<string>();
    l.Add("test 1");
    l.Add("test 2");
    
    for (int i = 0; i < l.Count; i++ )
    {
        l[i] = l[i] + " doing";
        Console.WriteLine(l[i]);
    }
