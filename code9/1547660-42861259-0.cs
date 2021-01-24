    var query = ctx.Articles
                        .AsNoTracking()
                        .WithSmallIncludes();
    if(string.IsNullOrWhiteSpace(request.Title) && string.IsNullOrWhiteSpace(request.Summary))
        return query;
    
    Expression<Func<DbContext.Article, bool>> searchCondition = m => false;
    
    if (!string.IsNullOrWhiteSpace(request.Title))
        searchCondition = searchCondition.Or(m => m.Title.Contains(request.Title));
    
    
    if (!string.IsNullOrWhiteSpace(request.Summary))
         searchCondition = searchCondition.Or(m => m.Summary.Contains(request.Summary));
    
     query = query.AsExpandable().Where(searchCondition);
