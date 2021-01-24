    list.Aggregate(summary, (b, c) => 
    {
    	if (summary.ContainsKey(c.UpaName)) {
    		var sum = summary[c.UpaName];
    		sumarize(c, sum);
    	}
    	else
    	{
    		var sum = new InquirySummary();
    		summary.Add(c.UpaName, sum);
    		sumarize(c, sum);
    	}
    	return summary;
    });
