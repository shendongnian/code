    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    
    public class Program
    {
    	public class MyRow
    	{
    		public int Id { get; set; }
    		public string Name { get; set; }
    		public int Qunatity { get; set; }
    	}
    	
    	public static void Main()
    	{
    		var type = typeof(MyRow);
    		var constructorInfo = type.GetConstructor(new Type[0]);
    		var newExpression = Expression.New(constructorInfo);
    		
    		var memberInits = new List<MemberAssignment>();
    		foreach (var prop in type.GetProperties())
    		{
    			if (prop.Name == "Id")
    			{
    				memberInits.Add(Expression.Bind(prop, Expression.Constant(1)));
    			}
    			else if (prop.Name == "Name")
    			{
    				memberInits.Add(Expression.Bind(prop, Expression.Constant("Z_Name")));
    			}
    			else if (prop.Name == "Qunatity")
    			{
    				memberInits.Add(Expression.Bind(prop, Expression.Constant(2)));
    			}
    		}
    		
    		var expression = Expression.MemberInit(newExpression, memberInits);
    		
    		// FOR testing purpose
    		var compiledExpression = Expression.Lambda<Func<MyRow>>(expression).Compile();
    		var myRow = compiledExpression();
    		
    		Console.WriteLine(myRow.Id);
    		Console.WriteLine(myRow.Name);
    		Console.WriteLine(myRow.Qunatity);
    	}
    }
