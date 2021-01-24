    ParameterExpression expression = Expression.Parameter(typeof(Foo), "s");
    MemberBinding[] bindings = new MemberBinding[]
    {
        Expression.Bind(typeof(Allocation).GetProperty(nameof(Allocation.Id)), Expression.PropertyOrField(expression, nameof(Foo.Id))),
        Expression.Bind(typeof(Allocation).GetProperty(nameof(Allocation.UnitName)), Expression.PropertyOrField(expression, nameof(Foo.UnitName))),
        Expression.Bind(typeof(Allocation).GetProperty(nameof(Allocation.Address)), Expression.PropertyOrField(expression, nameof(Foo.NewAddress))),
        Expression.Bind(typeof(Allocation).GetProperty(nameof(Allocation.Tel)), Expression.PropertyOrField(expression, nameof(Foo.NewTel))),
    };
    ParameterExpression[] parameters = new ParameterExpression[] { expression };
    var lambda = Expression.Lambda<Func<Foo, Allocation>>(Expression.MemberInit(Expression.New(typeof(Allocation)), bindings), parameters);
