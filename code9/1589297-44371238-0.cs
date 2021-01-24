	IQueryable<Error> SearchProducts(Row row, string[] codes, string[] keywords)
	{
		var predicate = PredicateBuilder.False<Error>();
	
		foreach (string code  in codes)
		{
			string temp = code;
			predicate = predicate.Or(p => p.Code.Contains(temp));
		}
		foreach (string keyword in keywords)
		{
			string temp = keyword;
			predicate = predicate.Or(p => p.Description.Contains(temp));
		}
		return row.Errors.AsQueryable().Where(predicate);
	}
