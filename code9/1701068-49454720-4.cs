	using System;
	using System.Collections.Generic;
	using DynamicExpression=System.Linq.Dynamic.DynamicExpression; //nuget package
	using System.Linq.Expressions;
	public static class MyDynamics
	{			
	    public static Predicate<T> GetPredicate<T>(string stringExpression)
        {        
            var exp = DynamicExpression.ParseLambda<T, bool>(stringExpression).Compile();				
            var predicate = new Predicate<T>(exp);
            return predicate;
        }	
	}
		
