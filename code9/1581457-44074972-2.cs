    var example = Example(query);
    var p = Expression.Parameter(GetQueryType(query));
    var body = Expression.And(
        Expression.Equal(Expression.PropertyOrField(p, nameof(example.ID)),
            Expression.Constant(123)),
        Expression.Equal(Expression.PropertyOrField(p, nameof(example.PetName)),
            Expression.Constant("Jim"))
    );
