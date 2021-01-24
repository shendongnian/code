    using System;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using System.Reflection;
    	
    class ThisCss
    {
    	public int useThis(int num)
    	{
    		return 0;
    	}
    }
    
    
    public class Program
    {
    	public static Type ExtractClassType(Expression<Func<int>> methodCall)
    	{
    		if (methodCall.Body.NodeType == ExpressionType.Call)
    		{
    			MethodCallExpression memberExpression = (System.Linq.Expressions.MethodCallExpression)methodCall.Body;
    			MethodInfo memberInfo = memberExpression.Method;
    			return memberInfo.DeclaringType;
    		}
    		else
    		{
    			throw new InvalidOperationException("Unable to extract a method call from this expression");
    		}
    	}
    	
    	
    	
    	public static void Main()
    	{
    		var methods = new List<Expression<Func<int>>>();
    		methods.Add(() => new ThisCss().useThis(0));
    		
    		var type = ExtractClassType(methods[0]);
    		
    		Console.WriteLine("{0}", type);
    	}
    }
