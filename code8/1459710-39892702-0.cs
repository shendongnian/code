    var result = _context.Articles.AsNoTracking().Include(a => a.Tags)
                                  .SelectMany(a => a.Tags.Select(tag => new { Tag = tag, Article = a })
                                  .GroupBy(x => x.Tag)
                                  .OrderByDescending(g => g.Count())
                                  .Take(10);
