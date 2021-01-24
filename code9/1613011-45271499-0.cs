	if (!string.IsNullOrEmpty(qsId))
	{
		// default false
			var inner = PredicateBuilder.False<Product>();
		// first or
		inner = inner.Or (i => 
			   Regex.IsMatch(i.GetProperty("makeTag").Value.ToString(), "\\b" + 
			   qsId + "\\b");
		// second or	   
		inner = inner.Or (i => 
			string.IsNullOrEmpty(i.GetProperty("makeTag")).Value.ToString());
	
	
		predicate = predicate.And(inner);
	}		
