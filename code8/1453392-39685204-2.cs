ParameterExpression parameterType = Expression.Parameter(typeof(T), "object");
 
        public static class CustomExpression
        {
         // Create Initial Expression Tree
         public static BinaryExpression InitialExpression<T,T1>(
                                                                ParameterExpression parameterType
    													        string columnName,
    													        T1 value)
    	{
            // Optional can be taken outside the Extension method to create a Func<T,bool>
    		//ParameterExpression parameterType = Expression.Parameter(typeof(T), "object");
    
    		MemberExpression typeColumn = Expression.Property(parameterType, columnName);
    
    		ConstantExpression constant = Expression.Constant(value, typeof(T1));
    
    		return Expression.NotEqual(typeColumn, constant);
    	}
        // Create Combined Expression Tree
        public static BinaryExpression CombinedExpression<T,T1>(this BinaryExpression mainExpression,
                                                                ParameterExpression parameterType
    													        string columnName,
    													        T1 value)
    	{
            // Optional can be taken outside the Extension method to create a Func<T,bool>
    		//ParameterExpression parameterType = Expression.Parameter(typeof(T), "object");
    
    		MemberExpression typeColumn = Expression.Property(parameterType, columnName);
    
    		ConstantExpression constant = Expression.Constant(value, typeof(T1));
    
    		return Expression.And(mainExpression,Expression.NotEqual(typeColumn, constant));
    	}
        }
