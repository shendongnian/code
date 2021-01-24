    public List<TResult> ToList()
    {
        var list = new List<TResult>();
        foreach (TSource item in _source)
        {
            list.Add(_selector(item));
        }
        return list;
    }
