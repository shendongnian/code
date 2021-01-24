    public bool CanCast<TId>()
    {
        var identifiableT = typeof(IIdentifiable<>).MakeGenericType(typeof(TId));
        return identifiableT.IsAssignableFrom(typeof(T));
    }
    public IEnumerable<IIdentifiable<TId>> Filter<TId>(IEnumerable<T> data)
    {
        return data.Where(d => _dataSource.All(
          ds => !((IIdentifiable<TId>) ds).Id.Equals(((IIdentifiable<TId>) d).Id)));
    }
