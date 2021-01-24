    public Dictionary<string, string> Test()
    {
        Dictionary<string, string> d = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    
        d.Add("name", "test");
        return d;
    }
