	void Main()
	{
		GenericFactory.CreateGeneric<int>();
		GenericFactory.CreateGeneric<string>();
	}
	public static class GenericFactory
	{
		private static Dictionary<Type, Type> registeredTypes = new Dictionary<System.Type, System.Type>();
	
		static GenericFactory()
		{
			registeredTypes.Add(typeof(int), typeof(GenericInt));
			registeredTypes.Add(typeof(string), typeof(GenericString));
		}
		
		public static IGeneric<T> CreateGeneric<T>()
		{
			var t = typeof(T);
			if (registeredTypes.ContainsKey(t) == false) throw new NotSupportedException();
			
			var typeToCreate = registeredTypes[t];
			return Activator.CreateInstance(typeToCreate, true) as IGeneric<T>;
		}
	
	}
	
	public interface IGeneric<TId>
	{
		TId Id { get; set; }
	
		void ProcessEntity(TId id);
	}
	
	public class GenericInt : IGeneric<int>
	{
		public int Id { get; set; }
	
		public void ProcessEntity(int id)
		{
			Console.WriteLine(id);
		}
	}
	
	public class GenericString : IGeneric<string>
	{
		public string Id { get; set; }
	
		public void ProcessEntity(string id)
		{
			Console.WriteLine(id);
		}
	}
