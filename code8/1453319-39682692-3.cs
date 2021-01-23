    private IQueryable<SomeClass> FilterCommon(IQueryable<SomeClass> query
        , Filter filter
        , Func<Filter, Dictionary<Guid, string>> getDictionary
        , Func<SomeClass, Guid> getKey)
    {
        IQueryable<SomeClass> result = null;
        Dictionary<Guid, string> commonDictionary = getDictionary(filter);
        if (commonDictionary != null && commonDictionary.Any())
        {
            result = query.Where(x => commonDictionary.ContainsKey(getKey(x)));
        }
        return result;
    }
