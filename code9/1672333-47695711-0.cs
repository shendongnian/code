    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Dynamic;
    
    public class Program
    {
    	public static void Main()
    	{		
    		var foo = new Foo<User>();
    
            foo.data.Add(new User() { id = 1, LastName = "User1", Other = "A" });
            foo.data.Add(new User() { id = 2, LastName = "User2", Other = "B" });
            foo.data.Add(new User() { id = 3, LastName = "User3", Other = "C" });
    
            foo.AddExpression(u => u.id);
            foo.AddExpression(u => u.LastName);
    
            var result = foo.CreateNewByExpression(); 
    		Console.WriteLine(result.First().LastName);
    	}
    }
    
    public class User
    {
        public int id { get; set; }
    	
        public string LastName { get; set; }
    
        public string Other { get; set; }
    
    }
    
    public class Foo<T>
    {
    	public List<T> data = new List<T>();
    	
    	public List<Expression<Func<T, object>>> SelectExpressionsList = new List<Expression<Func<T, object>>>();
    	
    	public IEnumerable<dynamic> CreateNewByExpression()
    	{
    		foreach (var item in data)
    		{
    			IDictionary<string, object> result = new ExpandoObject();
    			foreach (var exp in SelectExpressionsList)
    			{
    				string name = GetMember(exp.Body).Member.Name;
    				result[name] = exp.Compile()(item);
    			}
    
    			yield return result as ExpandoObject;
    		}
    	}
    
    	public void AddExpression(Expression<Func<T, object>> exp)
    	{
    		SelectExpressionsList.Add(exp);
    	}
    
    	public static MemberExpression GetMember(Expression expression)
    	{
    		MemberExpression exp = null;
    		switch (expression.NodeType)
    		{
    			case ExpressionType.MemberAccess:
    				exp = expression as MemberExpression;
    				break;
    			case ExpressionType.Convert:
    				exp = ((UnaryExpression)expression).Operand as MemberExpression;
    				break;
    			default:
    				break;
    		}
    
    		return exp;
    	}
    }
