    public class User {
		public string Name {get;set;}
	}
	
	public static void Main()
	{
		var user = new User();
		var assigner = GetAssigner<User, string>(u => u.Name);
		assigner.Compile()(user, "Joe");
		Console.WriteLine(user.Name);
	}
	
	public static Expression<Action<TClass, TValue>> GetAssigner<TClass, TValue>(Expression<Func<TClass, TValue>> propertyAccessor){
		var prop = ((MemberExpression)propertyAccessor.Body).Member;
		var typeParam = Expression.Parameter(typeof(TClass));
		var valueParam = Expression.Parameter(typeof(TValue));
		return Expression.Lambda<Action<TClass, TValue>>(
			Expression.Assign(
				Expression.MakeMemberAccess(typeParam, prop),
				valueParam), typeParam, valueParam);
	}
