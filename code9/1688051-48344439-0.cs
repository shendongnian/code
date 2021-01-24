    public class Program
    {
    
    	public static void Main()
    	{
    		var user = new User();
    		user.Department = new Department();
    		user.Department.Name = "hello";
    		Console.WriteLine("Before: " + user.Department.Name);
    		
            ParameterExpression paramExpr = Expression.Parameter(typeof(User), "user");
            MemberExpression depPropExpr = MemberExpression.Property(paramExpr, "Department");
            MemberExpression depNamePropExpr = MemberExpression.Property(depPropExpr, "Name");
            ConstantExpression constantExpression = Expression.Constant("SBCA");
    
            var expression = Expression.Assign(depNamePropExpr, constantExpression);
    		
    		var compiledExpression = Expression.Lambda<Action<User>>(expression, new[] { paramExpr }).Compile();
            compiledExpression(user);
    		Console.WriteLine("After: " + user.Department.Name);
    	}
    }
    
    public class User
    {
    	public Department Department { get; set; }
    }
    
    public class Department
    {
    	public string Name { get; set; }	
    }
