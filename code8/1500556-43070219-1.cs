    public List<string> ProvidedActions()
    {
        List<string> lst = new List<string>();
        foreach(Type t in providedActions)
            lst.Add(t.Name);
        return lst;
    }
