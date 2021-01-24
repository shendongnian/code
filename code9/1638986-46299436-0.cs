    // id
    var id = 2;
    var idConstant = Expression.Constant(id);
    // e => ...
    var param = Expression.Parameter(modelType);
    // e => e.ID
    var propertyExpression = Expression.PropertyOrField(param, "ID");
    // e => e.ID == id
    var body = Expression.Equal(propertyExpression, idConstant);
    
    var lambda = Expression.Lambda<Func<object, bool>>(body, param);
