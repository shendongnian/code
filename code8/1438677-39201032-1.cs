    public IList<TResult> GetStuff(string selector) {
      return GetStuffCore(selector).ToList();
    }
    public async Task<IList<TResult>> GetStuffAsync(string selector) {
      return await GetStuffCore(selector).ToListAsync();
    }
    private IQueryable<TResult> GetStuffCore(string selector)
      return from s in ctx.Stuff
             where s.Thing.Contains(selector)
             // lots of LINQ
             select some-complex expression;
    }
