    private IList<Filter> CombineFilters(IList<Filter> first, IList<Filter> second)
    {
    
        if (first == null && second == null) 
        {
        	return null;
        }
        
        return (first ?? Enumerable.Empty<Filter>())
        		.Concat(second ?? Enumerable.Empty<Filter>())
                .ToList();
    }
