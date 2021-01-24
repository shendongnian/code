    	public class MyClass
		{
			public IList<TEntity> GetData<TEntity>() where TEntity : class
			{
				return _DbContext.Set<TEntity>().ToList();
			}
			public void Test()
			{
				var type = GetTypeOf("View_Export_Books");
				var method = typeof(MyClass).GetMethod("GetData").MakeGenericMethod(type);
				var instance = Activator.CreateInstance(type);
				method.Invoke(instance, new object[]{ });
			}
			private Type GetTypeOf(string className)
			{
				var assembly = AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetTypes().Any(t => t.Name == className));
				return assembly.GetTypes().First(t => t.Name == className);
			}
		}
