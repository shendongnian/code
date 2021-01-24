    Random rnd = new Random();
    objArticles = context.Information.Where(i=> i.Category == category)
    .OrderBy(i=> rnd.Next())
    .Select(i=> new ArticlesDto
    {
         Id = i.Id,
         Headlines = i.Headlines,
         Url = i.Url,
         Category = i.Category,
         Summary = i.Summary
    }).Take(20);
