ParameterExpression parameterType = Expression.Parameter(typeof(T), "object");
 
        public static BinaryExpression CombinedExpression<T,T1>(this BinaryExpression mainExpression,
                                                                ParameterExpression parameterType
    													        string columnName,
    													        T1 value)
    	{
            // Optional can be taken outside the Extension method to create a Func<T,bool>
    		//ParameterExpression parameterType = Expression.Parameter(typeof(T), "object");
    
    		MemberExpression typeColumn = Expression.Property(parameterType, columnName);
    
    		ConstantExpression constant = Expression.Constant(value, typeof(T1));
    
    		BinaryExpression returnBinaryExpression = (mainExpression == null) ?
    		Expression.NotEqual(typeColumn, constant) : Expression.And(mainExpression,Expression.NotEqual(typeColumn, constant));
    		
    		return returnBinaryExpression;
    	}
