    //Creating LINQ query
    IEnumerable<Dictionary<object, object>> result = null;
    foreach (var joinSpec in joinSpecs) {
        result = joinSpec.PerformJoin(result);
    }
    //Executing the LINQ query
    var finalResult = result.ToList();
