    // id
    var id = 2;
    var idConstant = Expression.Constant(id);
    // (object e) => ...
    var param = Expression.Parameter(typeof(object));
    // (object e) => ((modelType)e).ID
    var property = Expression.PropertyOrField(Expression.Convert(param, modelType), "ID"));
    // (object e) => ((modelType)e).ID == id
    var body = Expression.Equal(property, idConstant);
    
    var lambda = Expression.Lambda<Func<object, bool>>(body, param);
