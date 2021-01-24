    // extract property name from passed expression
    var propertyName = ((MemberExpression)field.Body).Member.Name;            
    var param = Expression.Parameter(typeof(T), "object");            
    var searchConstant = Expression.Constant(search.Trim('*'));
    var contains = typeof(String).GetMethod("Contains");
    // object.FieldName.Contains(searchConstant)
    var inExp = Expression.Call(Expression.PropertyOrField(param, propertyName), contains, searchConstant);            
    // object => object.FieldName.Contains(searchConstant)
    var exp = Expression.Lambda<Func<T, bool>>(inExp, param);
