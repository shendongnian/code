    var predicate = PredicateBuilder.True<Product>();
    if(inputPrice > 100)
       predicate = predicate.And (p => p.Price > 100);
    if(inputName == "S%")
       predicate = predicate.And (p => p.Name.StartsWith("S"));
    
