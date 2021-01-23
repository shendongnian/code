    foreach (var keyword in keywords)
    {
        if (!String.IsNullOrEmpty(keyword))
        {
            var term = new Term(fieldToQuery, keyword.SanitizeSQL());
            multiPhraseQuery.Add(term);
        }
    }
