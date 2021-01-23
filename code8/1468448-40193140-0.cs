    [HttpGet]
    public async Task<IEnumerable<Word>> Get()
    {
        return _db.Words.Select(x => new  
                      {
                          x, x.Author.Select(y=>new { y.UserName })
                      }
                  ).ToList();
    }
