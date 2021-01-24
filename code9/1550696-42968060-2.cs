    public bool TryGetValue(string name, out object value)
    {
        var index = table.IndexOfName(name);
        if (index < 0)
        { // doesn't exist
            value = null;
            return false;
        }
        ...
    }
