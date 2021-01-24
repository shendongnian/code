    using System;
    using System.Linq.Expressions;
    
    namespace LinqKit
    {
    	public static class Extensions
    	{
    		public static Expression<Func<T, bool>> ToExpression<T>(this ExpressionStarter<T> expr) => expr;
    	}
    }
