	protected override Query NewTermQuery(Term term)
    {
	    var field = term.Field();
		var text = term.Text() ?? "";
		if (field == "contents" &&
			text.Length >= 3 &&
			text.IndexOfAny(new[] { '*', '?' }) < 0)
		{
			var wq = new WildcardQuery(new Term(field, text + "*"));
			return wq;
		}
		return base.NewTermQuery(term);
	}
