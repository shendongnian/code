    Expression<Func<DbContext.Article, bool>> searchCondition = null;
    Expression<Func<DbContext.Article, bool>> filterCondition = null;
    
    if (!string.IsNullOrWhiteSpace(request.Title))
    {
        searchCondition = m => m.Title.Contains(request.Title);
    }
        
    if (!string.IsNullOrWhiteSpace(request.Summary))
    {
         filterCondition = m => m.Summary.Contains(request.Summary);
         if(searchCondition == null) 
            searchCondition  = filterCondition;
         else   
            searchCondition = searchCondition.Or(filterCondition);
    }
    
    if(searchCondition != null)
       query = query.AsExpandable().Where(searchCondition);
