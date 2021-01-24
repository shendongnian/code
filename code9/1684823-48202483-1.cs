	class MysteryCode
	{
		public static Guid Foo { get { return new Guid("2b1bd512-6d75-4c63-9e2e-dfebda4f4393"); } }
		public static Guid Bar { get { return new Guid("2b1bd512-6d75-4c63-9e2e-dfebda4f4394"); } }
	}
						
	public class Program
	{
		public static Dictionary<Guid, PropertyInfo> FindGuids()
		{
			return System.Reflection.Assembly.GetExecutingAssembly()
				.GetTypes()
				.SelectMany
				(
					t => t.GetProperties
					(
						BindingFlags.Static | BindingFlags.Public
					)
				)
				.Where
				(
					p => p.PropertyType == typeof(Guid)
				)
				.ToDictionary
				(
					p => (Guid)p.GetValue(null),
					p => p
				);
		}
		
		public static void Main()
		{
			var dictionary = Program.FindGuids();
			
			foreach (var g in dictionary)
			{
				Console.WriteLine("{0} {1}.{2}", g.Key, g.Value.DeclaringType.FullName, g.Value.Name);
			}
		}
	}
