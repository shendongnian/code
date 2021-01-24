    public ThingObjects GetThings(ObjectParameter[] params, int count, int pageIndex)
    {
        var things = from t in Context.ExecuteFunction<Something>("function", params)
                 select new Thing
                 {
                     ID = t.ID
                 }).ToList();
        var countOfThings = things.Count;
        if (pageIndex >= 0)
            things = things.Skip(count * pageIndex).Take(count);
        return new ThingObjects(things, countOfThings);
    }
