    [HttpGet]
    public IEnumerable<object> Get()
    {
        return _db.Words.Include(x=>x.Author)
                        .Select(x => new { UserName = x.UserName})
                        .ToList();
    }
