    var mySet = SomeFactory.GetData();
    var predicate = PredicateBuilder.True<TypeOfmySet>();
    if(nameFilter != null){
      predicate = predicate.Or(item => item.Name == nameFilter);
    } 
    if (ageFilter != null){
      predicate = predicate.Or(item => item.Age == ageFilter);
    }
    //I don't know the myset has which type in IQueryable or already retrieved in memory collection. If it is IQueryable, don't compile the predicate otherwise compile it.
    //var compiledPredicate = predicate.Compile();
    mySet = mySet.Where(predicate);
