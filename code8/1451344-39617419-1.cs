    public Expression CreateNullPropagationExpression(Expression o, string property)
    {
    	Expression propertyAccess = Expression.Property(o, property);
    	
    	var propertyType = propertyAccess.Type;
    	
    	if (propertyType.IsValueType && Nullable.GetUnderlyingType(propertyType) == null)
    		propertyAccess = Expression.Convert(
                propertyAccess, typeof(Nullable<>).MakeGenericType(propertyType));
    	
    	var nullResult = Expression.Default(propertyAccess.Type);
    	
    	var condition = Expression.Equal(o, Expression.Constant(null, o.Type));
    	
    	return Expression.Condition(condition, nullResult, propertyAccess);
    }
