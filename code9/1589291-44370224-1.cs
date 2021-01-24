    var x = Expression.Parameter(typeof(T), "x");
    
    string keyPropName = type.GetPrimaryKey(ctx);
    var equalExp = Expression.Equal(
    	Expression.Property(x, keyPropName),
    	Expression.Constant(id)
    	);
    
    var lambda = Expression.Lambda<Func<T, bool>>(equalExp, x); //x => x.Id == idValue
    
    var myResult = tbl.FirstOrDefault(lambda);
