    var filterOfNames = new List<string> {"Sample", "Sample2"};
    var filterOfAges = new List<int> { 21, 33, 45 };
    var mySet = SomeFactory.GetData();
    var predicate = PredicateBuilder.True<TypeOfmySet>();
    foreach (var filterOfName in filterOfNames)
    {
    	//If it is the first predicate, you should apply "And"
    	if (predicate.Body.NodeType == ExpressionType.Constant)
    	{
    		predicate = predicate.And(x => x.Name == filterOfName);
    		continue;
    	}
    	predicate = predicate.Or(x => x.Name == filterOfName);
    }
    foreach (var filterOfAge in filterOfAges)
    {
    	//If it is the first predicate, you should apply "And"
    	if (predicate.Body.NodeType == ExpressionType.Constant)
    	{
    		predicate = predicate.And(x => x.Age == filterOfAge);
    		continue;
    	}
    	predicate = predicate.Or(x => x.Age == filterOfAge);
    }
    //I don't know the myset has which type in IQueryable or already retrieved in memory collection. If it is IQueryable, don't compile the predicate otherwise compile it.
    //var compiledPredicate = predicate.Compile();
    mySet = mySet.Where(predicate);
