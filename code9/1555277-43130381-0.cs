    public List<Thing> GetThings(ObjectParameter[] params, int pageIndex, int pageSize)
    {
        if (pageSize <= 0)
            pageSize = 1;
    
        if (pageIndex < 0)
            pageIndex = 0;
    
        var source = Context.ExecuteFunction<Something>("function", params);
    
        var total = source.Count();
    
        var things = (from t in source select new Thing { ID = t.ID })
                    .Skip(pageIndex * pageSize).Take(pageSize).ToList();
    
        return things.ToList();
    }
