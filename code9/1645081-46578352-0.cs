    MethodCallExpression toString;
    
    // Then assign it with Expression.Call(...);
    
    if (propertyName == nameof(CustomerListDto.Id))
    {
         toString = Expression.Call(propertyExp, typeof(int).GetMethod("ToString", System.Type.EmptyTypes));
    }
    else
    {
        toString = Expression.Call(propertyExp, typeof(int?).GetMethod("ToString", System.Type.EmptyTypes));
    }
