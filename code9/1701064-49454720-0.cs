		using System;
		using System.Collections.Generic;
		using DynamicExpression=System.Linq.Dynamic.DynamicExpression;
		using System.Linq.Expressions;
		public static class MyDynamics
		{
			
			public static Predicate<T> ToPredicate<T>(this Expression<Func<T, bool>> expression)
			{
				Func<T, bool> func = expression.Compile();
				Predicate<T> predicate = new Predicate<T>(func);				
				return predicate;
			}
		 
		
			public static Predicate<T> GetPredicate<T>(string expression)
			{        
				Expression<Func<T, bool>> func = DynamicExpression.ParseLambda<T, bool>(expression);				
				Console.WriteLine(func.Body);
				var e2 = func.ToPredicate();
				return e2;
			}
		
		}
		
