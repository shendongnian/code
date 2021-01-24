    void Copy(object from, object to)
    {
        var dict = to.GetType().GetProperties().ToDictionary(p => p.Name, p => p);
        foreach(var p in from.GetType().GetProperties())
        {
            dict[p.Name].SetValue(to, p.GetValue(from,null), null);
        }
    }
