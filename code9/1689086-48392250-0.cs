    var predicate = PredicateBuilder.New<TestNullableEnumClass>();
    var parameter = Expression.Parameter(typeof(TestNullableEnumClass), typeof(TestNullableEnumClass).Name);
    Expression member = Expression.Property(parameter, type.Name);
    var constant = Expression.Constant(TestingEnum.Item1);
    var constantConverted = Expression.Convert(constant, member.Type);
    var body = Expression.Equal(member, constantConverted);
    var expression = Expression.Lambda<Func<TestNullableEnumClass, bool>>(body, parameter);
    predicate.Or(expression);
