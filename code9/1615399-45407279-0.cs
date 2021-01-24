    `// There is a VSO limit of a query returning 20,000 results. Split into groups of 10,000 items maximum.
    var results = new List<WorkItemReference>();
    var counter = 10000;
    var moreResults = true;
    while (moreResults)
    {
    	List<WorkItemReference> currentResults = this.WitClient.QueryByWiqlAsync(new Wiql
    	{
    		Query = $"SELECT System.ID FROM WorkItems WHERE System.TeamProject = '{Project}' AND {customQuery} AND System.ID >= {counter - 10000} AND System.ID < {counter}"}).Result.WorkItems.ToList();`
    
    	if (currentResults.Count == 0)
    	{
    		// Verify there are no more items
    		try
    		{
    			results.AddRange(this.WitClient.QueryByWiqlAsync(new Wiql
    			{
    				Query = $"SELECT System.ID FROM WorkItems WHERE System.TeamProject = '{Project}' AND {customQuery} AND System.ID >= {counter}"
    			}).Result.WorkItems.ToList());
     
    			moreResults = false;
    		}
    		catch (Exception e)
    		{
    			if (e.ToString().Contains("VS402337"))
    			{
    				// There are still more results, so increment and try again.
    			}
    			else
    			{
    				throw;
    			}
    		}
    	}
    	else
    	{
    		results.AddRange(currentResults);
    	}
    
    	counter += 10000;
    }
