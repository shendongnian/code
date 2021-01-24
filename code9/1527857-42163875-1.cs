    IList<QuerySuggest> QuerySuggestions(RequestType request, bool filterByUser)
    {
        IRepository<QuerySuggest> repository = 
            _repositoryManager.GetRepository<QuerySuggest>(_repositoryType);
        var entities = repository
            .Query(c => c.Where(e => 
                e.IdWebsite == request.WebSiteId &&
                e.FulltextFree != null &&
                e.DataOra >= (System.DateTime.Today.AddDays(-60).Date) &&
                (!filterByUser || e.UserId == request.UserId)
            )
            .GroupBy(g => g.FulltextFree)
            .Select(n => new { FulltextFree = n.Key, HowMany = n.Count() })
            .Where(w => w.HowMany >= request.HowMany)
            .OrderBy(o => o.HowMany))
            .ToList();
        return entities;
    }
    IList<QuerySuggest> QuerySuggestionsByUser(RequestType request)
    {
        return QuerySuggestions(request, filterByUser: true);
    }
    IList<QuerySuggest> QuerySuggestionsAnyUser(RequestType request)
    {
        return QuerySuggestions(request, filterByUser: false);
    }
