    var a = new Dictionary<TK,TV>();
    var b = new Dictionary<TK,TV>();
    
    var isEquals = a.All(x =>
    {
        TV v;
        if (b.TryGetValue(x.Key, out v))
           return x.Value.Equals(v);
    
        return false;
    }
