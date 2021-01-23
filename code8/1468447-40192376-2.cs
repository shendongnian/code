    [HttpGet]
    public async Task<IEnumerable<WordDto>> Get()
    {
        return _db.Words
                  .Include(x=>x.Author)
                  .Select(x =>
                      new WordDto 
                      {
                          Title = x.Title,
                          DateTime = x.WhenCreated,
                          AuthorName = x.Author?.UserName ?? string.Empty
                      }
                  )
                  .ToListAsync();
    }
