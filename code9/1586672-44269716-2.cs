    TaxonomySession session = TaxonomySession.GetTaxonomySession(context);
    var store = session.GetDefaultKeywordsTermStore();
    var terms = store.KeywordsTermSet.GetAllTerms();
    context.Load(store, i => i.DefaultLanguage);
    context.ExecuteQuery();
    var collection = new System.Collections.ObjectModel.Collection<Term>();
	var keywords = new string[] { "Key1", "Key2" };
	foreach (var key in keywords)
	{
		var filtered = context.LoadQuery(terms.Where(t => t.Name == key));
		context.ExecuteQuery();
		var term = filtered.SingleOrDefault();
		if (term != null)
			collection.Add(term);
	}
