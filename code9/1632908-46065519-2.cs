    public List<DateTime> CompareDates(List<DateTime[]> compareRanges, int overlapThreshold = 1)
    {
	    var overlaps = new List<DateTime>();
    	var intersectTable = new List<DateTime>[compareRanges.Count];
	
	    // simple nested loop...
    	for (var outer = 0; outer < compareRanges.Count - 1; outer++)
	    {
		    var outerRange = compareRanges[outer];
		
    		for (var inner = outer + 1; inner < compareRanges.Count; inner++)
	    	{
		    	var innerRange = compareRanges[inner];
			    var intersect = outerRange.Intersect(innerRange).ToList();
    			if (intersect.Any())
	    		{
		    		if (intersectTable[outer] == null)
			    	{
				    	intersectTable[outer] = new List<DateTime>();
    				} 
				
    				if (intersectTable[inner] == null)
	    			{
		    			intersectTable[inner] = new List<DateTime>();
			    	}
				
				    foreach (var dt in intersect)
    				{
	    				if (!intersectTable[outer].Contains(dt))
		    			{
			    			intersectTable[outer].Add(dt);
				    	}
					    if (!intersectTable[inner].Contains(dt))
    					{
    						intersectTable[inner].Add(dt);
    					}
    				}
    			}
    		}
    	}
	    // short circuit if no overlap threshold >= 2 specified...
    	if (overlapThreshold == 1)
    	{
	    	overlaps = intersectTable.SelectMany(r => r).Distinct().ToList();
    	}
    	// now that we have a comprehensive list of all overlaps
    	// let's only return overlaps that meet the threshold criteria
    	overlaps = intersectTable
	    	.SelectMany(r => r)
		    .GroupBy(t => t)
    		.Where(g => g.Count() >= overlapThreshold)
	    	.Select(g => g.Key)
		    .ToList();
	
    	return overlaps.OrderBy(d => d).ToList();
    }
