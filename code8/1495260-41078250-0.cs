    public static void Main()
	{
		var roleType = typeof(User.Role);
		
		var context = new FakeDbContext();
		
		var propertyInfo = GetDbSetProperty(roleType, context);
		
		Console.WriteLine(propertyInfo.Name);
	}
	
	public static PropertyInfo GetDbSetProperty(Type typeOfEntity, FakeDbContext context)
	{
		var genericDbSetType = typeof(DbSet<>);
		// typeof(DbSet<User.Role>);
		var entityDbSetType = genericDbSetType.MakeGenericType(typeOfEntity);
		
		// DbContext type
		var contextType = context.GetType();
		
		return contextType
			.GetProperties(BindingFlags.Public | BindingFlags.Instance)
			.Where(p => p.PropertyType == entityDbSetType)
			.FirstOrDefault();		
	}
	
	public class FakeDbContext
	{
		public DbSet<User.Role> Roles { get; set; }
	}
	
	public class DbSet<T>
	{
	}
	
	public class User
	{
		public class Role
		{
		}
	}
