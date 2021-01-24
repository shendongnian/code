    void count(List<string> l, Dictionary<string, int> d)
    {
        var text = l;
        var wp = new Regex(@"\w+");
        foreach (Match m in wp.Matches(text[0])) //using text[0] for 1st string
        {
            if (!d.ContainsKey(m.Value))
            { d.Add(m.Value, 1); }
            else
                d[m.Value]++;
        }
    }
    //for Printing
    foreach(var pair in dict) 
    {
        Console.WriteLine("{0 },{1}", pair.Key, pair.Value);
    }
