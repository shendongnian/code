    var dynamicGlobalFilter = PredicateBuilder.New<users>();
    dynamicGlobalFilter = dynamicGlobalFilter.And(x => x.username.Contains("w"));
    
    var test = users.Where(dynamicGlobalFilter);
    test.Dump();
