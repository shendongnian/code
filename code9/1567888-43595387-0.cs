    protected void Synchronize<T>(string resource, Func<T, Expression<Func<T, bool>>> predicateFactory) where T : class
    {
        var list = _context.RestClient.Get<List<T>>(resource);
    
        using (var repo = new Repository<GmaoContext, T>())
        {
            list.ForEach(x =>
            {
                repo.AddIfNotExists(x, predicateFactory(x));
            });
    
            repo.Save();
        }
    }
