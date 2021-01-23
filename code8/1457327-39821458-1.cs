    Dictionary<Type, StyleDel<Control>) _dict = ...
    public bool Add<T>(StyleDel<T> styleDel) where T : Control
    {
        var inDict = _dict.ContainsKey(typeof(T)); 
        if (!inDict) _dict[typeof(T)] = d => StyleDel((T)d);
        return inDict;
    }
