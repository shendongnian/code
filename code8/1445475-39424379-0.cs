     public int StupidFunction()
    {
        var context = GetContext();
        int skip = 0;
        int take = 100000;
        var batch = context.VarsHG19.OrderBy(v => v.Id).Skip(skip).Take(take).ToList();
        while (batch.Any())
        {
            
            skip += take;
            batch = context.VarsHG19.OrderBy(v => v.Id).Skip(skip).Take(take).ToList();
        }
    
        return 1;
    }
