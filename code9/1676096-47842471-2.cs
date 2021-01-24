    public class AndAlsoVisitor : ExpressionVisitor {
		protected override Expression VisitLambda<T>(Expression<T> node) {
			// Make it lambda expression
			var lambda = node as LambdaExpression;
			// This should never happen
			if (node != null) {
				// Create property access 
				var lengthAccess = Expression.MakeMemberAccess(
					lambda.Parameters[0],
					lambda.Parameters[0].Type.GetProperty("Length")
				);
				// Create p.Length >= 10
				var cond1 = Expression.LessThanOrEqual(lengthAccess, Expression.Constant(10));
				// Create p.Length >= 3
				var cond2 = Expression.GreaterThanOrEqual(lengthAccess, Expression.Constant(3));
				// Create p.Length >= 10 && p.Length >= 3
				var merged = Expression.AndAlso(cond1, cond2);
				// Merge old expression with new one we have created
				var final = Expression.AndAlso(lambda.Body, merged);
				// Create lambda expression
				var result = Expression.Lambda(final, lambda.Parameters);
				// Return result
				return result;
			}
			return null;
		}
	}
