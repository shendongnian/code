    var p = Expression.Parameter(GetQueryType(query));
    var body = Expression.And(
        Expression.Equal(Expression.PropertyOrField(p, "ID"), Expression.Constant(123)),
        Expression.Equal(Expression.PropertyOrField(p, "PetName"), Expression.Constant("Jim"))
    );
    var filtered = ApplyPredicate(query, body, p);
