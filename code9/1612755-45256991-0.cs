    public IEnumerable<T> CommonItems<T>(IEnumerable<IEnumerable<T>> collections)
    {
        var first = collections.FirstOrDefault();
        if(first == null)
            return Enumerable<T>.Empty();
        var overall = new HashSet<T>(first);
        foreach(var collection in collections.Skip(1))
        {
            var common = new HashSet<T>();
            foreach(var item in collection)
            {
                if(hash.Contains(item))
                    common.Add(item);
            }
            overall = common;
            if(overall.Count == 0)
                break;
        }
        return overall;
    }
