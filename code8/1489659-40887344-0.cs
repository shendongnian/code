    var predicate = PredicateBuilder.New<People>();
    if(model.FirstName != null)
       predicate = predicate.Or(p => p.FirstName.Contains(model.FirstName));
    if(model.LastName!= null)
       predicate = predicate.Or(p => p.LastName.Contains(model.LastName));
    if(model.MiddleName!= null)
       predicate = predicate.Or(p => p.MiddleName.Contains(model.MiddleName));
    
    var result = context.People..AsExpandable().Where(predicate).ToList();
