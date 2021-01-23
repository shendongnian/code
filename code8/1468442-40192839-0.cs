    public GetData()
    {
        var data = _ctx.Requests
            .Include(p => p.CountView)
            .AsNoTracking()
            .Select(a => a.CountView)
            .ToList();
        return data;
    }
