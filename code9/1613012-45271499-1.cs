	if (!string.IsNullOrEmpty(qsId))
	{
		// default false
		var predicate = PredicateBuilder.False<Product>();
		// first or
		predicate = predicate.Or (i => 
			   Regex.IsMatch(i.GetProperty("makeTag").Value.ToString(), "\\b" + 
			   qsId + "\\b");
		// second or	   
		predicate = predicate.Or (i => 
			string.IsNullOrEmpty(i.GetProperty("makeTag")).Value.ToString());
	}
