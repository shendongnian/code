    public enum Field
    {
        Id,
        TenantId,
        StartTime,
        ...
    }
    public enum Direction
    {
        Ascending,
        Descending,
    }
    public IEnumerable<T> Sort<T, KEY>(IEnumerable<T> l, Direction d, Func<T, KEY> getKey)
    {
        switch (d)
        {
            case Direction.Ascending:  return l.OrderBy(getKey);
            case Direction.Descending: return l.OrderByDescending(getKey);
            default:                   return l;
        }
    }
    public IEnumerable<ApiResponseTime> orderBy(Field f, Direction d, IEnumerable<ApiResponseTime> l)
    {
        switch (f)
        {
            case Field.Id:         return Sort(l, d, x => x.id);
            case Field.StartTime:  return Sort(l, d, x => x.start_time);
            // and so on
        }
    }
