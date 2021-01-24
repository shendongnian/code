    static Expression<Func<T, bool>> BuildKeyPredicate<T>(DbContext db, object[] id)
    {
    	var keyProperties = db.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;
    	var parameter = Expression.Parameter(typeof(T), "e");
    	var body = keyProperties
    		// e => e.PK[i] == id[i]
    		.Select((p, i) => Expression.Equal(
    			Expression.Property(parameter, p.Name),
    			Expression.Convert(
    				Expression.PropertyOrField(Expression.Constant(new { id = id[i] }), "id"),
    				p.ClrType)))
    		.Aggregate(Expression.AndAlso);
    	return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
