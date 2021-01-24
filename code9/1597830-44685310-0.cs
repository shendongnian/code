    public IEnumerable<DistributionItem> Process()
    {
        int slots = 20;
        Dictionary<string, double> distributions = new Dictionary<string, double>(){
			{ "A", .25 },
			{ "B", .25 },
			{ "C", .50 }
		}
	    List<DistributionItem> items = new List<DistributionItem>();
			
	    foreach(var d in distributions )
	    {
		    int count = (int)(slots * d.Value);
			for(int i = 0; i < count; i++)
			{
				items.Add(new DistributionItem(d.Key));
			}
		}	
		return items.OrderBy(x => Guid.NewGuid());
	}
