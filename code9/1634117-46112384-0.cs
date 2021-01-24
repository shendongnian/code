	public List<DTO.ArticleDTO> GetRecentArticles(int portalID, int moduleID, int domainID, int rootKnowledgeTypeID, int count)
	{
		var allArticles = _Context.Articles.LatestArticles(_Context.ArticleVersions, portalID, moduleID);
		var filteredArticles = new List<DTO.ArticleDTO>();
		
		foreach (DTO.ArticleDTO article in allArticles)
		{
			var domains = _GetRootDomainsForArticle(article.ArticleID, article.Version, rootKnowledgeTypeID);
			if (domains.Contains(domainID)
			{
				filteredArticles.Add(article);
			}
		}
		
		var articles = filteredArticles.OrderBy(article.UpdatedOn).Descending().Select(article => new DTO.ArticleDTO {
			ArticleID = article.ArticleID,
			Title = article.Title,
			Summary = article.Introduction,
			Content = article.Content,
			UpdatedOn = article.UpdatedOn,
			Version = article.Version,
			KnowledgeTypeText = (from category in _Context.Categories
											  join categoryVersion in _Context.ArticleCategoryVersions
											  on category.CategoryID equals categoryVersion.CategoryID
											  where
												categoryVersion.Version == article.Version &&
												categoryVersion.ArticleID == article.ArticleID &&
												category.ParentID == rootKnowledgeTypeID
											  select
												category.Name
											).First()
		}).Take(count).ToList();
	}
