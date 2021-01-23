    public int StupidFunction()
    {
        var context = GetContext();
        int skip = 0;
        int take = 100000;
        var batch = context.VarsHG19.AsNoTracking().OrderBy(v => v.Id).Skip(skip).Take(take);
        while (batch.Any())
        {
            batch.ToList();
            skip += take;
            batch = context.VarsHG19.AsNoTracking().OrderBy(v => v.Id).Skip(skip).Take(take);
        }
    
        return 1;
    }
