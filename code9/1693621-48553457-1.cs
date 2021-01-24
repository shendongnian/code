    var dynamicGlobalFilter = PredicateBuilder.True<users>();
	dynamicGlobalFilter = dynamicGlobalFilter.And(x => x.username.Contains("w"))
	var test = users.AsExpandable().Where(dynamicGlobalFilter);
	test.Dump();
         
