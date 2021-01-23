    namespace Foo {
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;   
    
    
    					
    public class Program
    {
    	public static void Main()
    	{
    		var parent = new Parent {
    			Children = new List<Child> { 
    				new Child(),
    				new Child(),
    				new Child()
    			}
    		};
    		
    		{
    		// works
    		
    		var expr = BuildLambda<Parent, IEnumerable<Child>>("Children");
    		
    		expr.Compile().Invoke(parent).ToList().ForEach(x => Console.WriteLine(x));
    		}
    		
    		// works too
    		{
    				
    		var expr2 = BuildLambda<Parent, IEnumerable<object>>("Children");
    		
    		expr2.Compile().Invoke(parent).ToList().ForEach(x => Console.WriteLine(x));
    		}
    		
    		// and this works too
    		ValidateEntity(parent);
    	
    	}
    	
    	
    	public static void ValidateEntity<TEntity>(TEntity e) 
    		where TEntity : class, new()
            {
                var propertyName = "Children";
                var propType = typeof(TEntity).GetProperty(propertyName);
    			
    			
    			var expr = typeof(Program)
    				.GetMethod("BuildLambda", BindingFlags.Public | BindingFlags.Static)
    				.MakeGenericMethod(new[] { typeof(TEntity), propType.PropertyType })
    				.Invoke(null, new[] {propertyName});
    			
    			// Here we invoke artificial method and inject property type there
                typeof(Program).GetMethod("ProcessExpr")
    				.MakeGenericMethod(new[] { typeof(TEntity), propType.PropertyType })
    				.Invoke(null, new [] { expr, e });
    			
    		}
    	
    	
    	public static void ProcessExpr<TEntity, TValue>(Expression<Func<TEntity, TValue>> expr, TEntity parent) {
    		// here we know both types
    		Console.WriteLine("Yay works too!");
    		((IEnumerable<Child>)expr.Compile().Invoke(parent)).Cast<Child>().ToList().ForEach(x => Console.WriteLine(x));
    	}
    	
    	
    	public static Expression<Func<TEntity, TValue>> BuildLambda<TEntity, TValue>(string property) where TEntity : class
            {
                var param = Expression.Parameter(typeof (TEntity), "e");
                var prop = Expression.PropertyOrField(param, property);
                return Expression.Lambda<Func<TEntity, TValue>>(prop, param); 
            }
    }
    
    public class Parent {
    
    	public List<Child> Children { get; set; }
    }
    
    public class Child { }
    	
    }
