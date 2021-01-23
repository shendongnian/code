    var predicate = PredicateBuilder.New<People>();
    if(!String.IsNullOrEmpty(model.FirstName))
       predicate = predicate.Or(p => p.FirstName.Contains(model.FirstName));
    if(!String.IsNullOrEmpty(model.LastName))
       predicate = predicate.Or(p => p.LastName.Contains(model.LastName));
    if(!String.IsNullOrEmpty(model.MiddleName))
       predicate = predicate.Or(p => p.MiddleName.Contains(model.MiddleName));
    
    var result = context.People..AsExpandable().Where(predicate).ToList();
