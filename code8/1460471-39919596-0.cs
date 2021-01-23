    var query = context.DP_ARTICLES; 
    if(predicate) 
       query=  query.OrderBy(article => article.ART_NUM);
    else if(predicate2) 
       query = //Second Order by clause
    .... //More sort options
    else 
       //Default action if needed
    
    var results = query.select(article => new ArticleItem
                                          { 
                                              Article = article
                                          }).ToList(); 
