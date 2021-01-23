    public IQueryable<SomeClass> FilterCommon(IQueryable<SomeClass> query
        , Dictionary<Guid, string> commonDictionary
        , Func<SomeClass,Guid> getKey)
    {
        IQueryable<SomeClass> result = null;
        if (commonDictionary != null && commonDictionary.Any())
        {
            result = query.Where(x => commonDictionary.ContainsKey(getKey(x)));
        }
        return result;
    }
