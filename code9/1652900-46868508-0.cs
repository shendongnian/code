    var articlesGrouped = context.Article
                                 .Where(g=>g.CreatedTime!=null)
                                 .GroupBy(x => new { Month = x.CreatedTime.Value.Month,
                                                     Year = x.CreatedTime.Value.Year })
                                 .ToList();
