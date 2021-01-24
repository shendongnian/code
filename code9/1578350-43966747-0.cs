	public static Expression<Func<T, bool>> ContainsValue<T>(string fieldName, string val) {
		var type = typeof(T);
		var member = Expression.Parameter(type, "param");
		var memberExpression = Expression.PropertyOrField( member, fieldName);
		var targetMethod = memberExpression.Type.GetMethod( "IndexOf", new Type[] { typeof(string), typeof(StringComparison) } );
		var methodCallExpression = Expression.Call( memberExpression, targetMethod, Expression.Constant(val), Expression.Constant( StringComparison.CurrentCultureIgnoreCase ) );
		
		return Expression.Lambda<Func<T, bool>>( 
			Expression.AndAlso(
				Expression.NotEqual(memberExpression, Expression.Constant(null)), 
				Expression.GreaterThanOrEqual( methodCallExpression, Expression.Constant(0) )
			), 
			member
		);
	}
