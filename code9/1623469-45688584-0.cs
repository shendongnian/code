    private IList<Filter> CombineFilters(IList<Filter> first, IList<Filter> second)
    {
    
        if (first == null && second == null) 
        {
        	return null;
        }
        
        return (foo ?? Enumerable.Empty<Filter>())
        		.Concat(bar ?? Enumerable.Empty<Filter>())
                .ToList();
    }
