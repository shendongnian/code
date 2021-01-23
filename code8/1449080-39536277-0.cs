    string [] my_list = new string [] {"StringA", "StringB", "StringC"};
    
    foreach (var g in groups)
    {
        foreach (string s in my_list)
        {
            file = g.Where(i => i.URL.Contains("StringB")).FirstOrDefault();
            if (file != null)
                break;
        }
        if (file == null)
        {
            file = g.FirstOrDefault();
        }
    }
