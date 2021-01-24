	public Task<string> GetName(string title)
	{
		var articleList = await _cache.GetOrCreateAsync("CacheKey", entry =>
		{
			entry.SlidingExpiration = TimeSpan.FromSeconds(60 * 60);
			return await _dbContext.Articles.ToListAsync();
		});
		var article = await articleList.Where(c => c.Title == title).FirstOrDefaultAsync();
		if(article == null)
		{
			return "Non exist"
		}
		return article.Name();
	}
	
