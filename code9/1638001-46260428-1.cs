    var parameterExp = Expression.Parameter(typeof(Boat), "x");
    Expression propertyExp = Expression.Property(parameterExp, "Accounts");
    Type elementType = propertyExp.Type.GetGenericArguments()[0];
    MethodInfo method1 = typeof(Enumerable).GetMethods(BindingFlags.Public | BindingFlags.Static).First(m => m.Name == "FirstOrDefault");
    // This gives me a Queryable of Account FirstOrDefault
    var specificMethod = method1.MakeGenericMethod(elementType);
    //propertyExp = Expression.TypeAs(propertyExp, typeof(IEnumerable<>).MakeGenericType(elementType));
    var firstOrDefaultAccountExpression = Expression.Call(specificMethod, propertyExp);
    var idExpr = Expression.PropertyOrField(firstOrDefaultAccountExpression, "Id");
    MethodInfo method = typeof(long).GetMethod("Equals", new[] { typeof(long) });
    var someValue = Expression.Constant(AccountId, typeof(long));
    var containsMethodExp = Expression.Call(idExpr, method, someValue);
    Expression<Func<Boat, bool>> predicate = Expression.Lambda<Func<Boat, bool>>
                 (containsMethodExp, parameterExp);
    repo = repo.Where(predicate);
