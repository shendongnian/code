    {
    	private IEnumerable<MyCollectionItem> inputData = new List<MyCollectionItem> {};
    	var queryBuilder = new MyCollectionQueryBuilder(inputData.AsQueryable()); //Linq IQueryable
    	q = queryBuilder.WithCol1Filter("filter_value").Build();
    	var res = q.ToList();
    }
