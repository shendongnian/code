    //Or
	var orPredicate = PredicateBuilder.Or(StudentIsActive(), StudentIsBusy());
    var orders1 = context.Orders.AsExpandable().Where(orPredicate);
    //And
	var andPredicate = PredicateBuilder.And(StudentIsActive(), StudentIsBusy());
    var orders2 = context.Orders.AsExpandable().Where(andPredicate);
