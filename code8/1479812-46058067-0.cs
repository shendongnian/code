    var filters = new List<IModelFilter>();
    TextMatchFilter highlightingFilter = null;
    if (!String.IsNullOrEmpty(txtSearch.Text))
    {
	    var words = txtSearch.Text.Trim().Split(null);
	    highlightingFilter = TextMatchFilter.Contains(ListView, words);
	    foreach (var word in words)
	    {
		    var filter = TextMatchFilter.Contains(ListView, word);
		    filters.Add(filter);
	    }
    }
    var compositeFilter = new CompositeAllFilter(filters);
    ListView.ModelFilter = highlightingFilter;
	ListView.AdditionalFilter = compositeFilter;
	ListView.DefaultRenderer = new HighlightTextRenderer(highlightingFilter);
