    Random rnd = new Random();
    objArticles = context.Information.Where(i=> i.Category == category).
                 OrderBy(i=> rnd.Next()).Select(i=> new ArticlesDto{
                                                                     Id = j.Id,
                                                                     Headlines = j.Headlines,
                                                                     Url = j.Url,
                                                                     Category = j.Category,
                                                                     Summary = j.Summary
                                                                   }).Take(20);
