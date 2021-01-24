    TaxonomySession session = TaxonomySession.GetTaxonomySession(context);
    var store = session.GetDefaultKeywordsTermStore();
    var terms = store.KeywordsTermSet.GetAllTerms();
    var keywords = new string[] { "Key1", "Key2" };
    var filtered = context.LoadQuery(terms.Where(t => keywords.Contains(t.Name)));
    context.ExecuteQuery();
