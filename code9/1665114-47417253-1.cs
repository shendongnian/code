	public class Program
	{
		public static void Main(string[] args)
		{
			var l1 = new List<ClassB>()
			{
				new ClassB() { KeyOne = 3, KeyTwo = 0 },
				new ClassB() { KeyOne = 5, KeyTwo = 0 },
				new ClassB() { KeyOne = 3, KeyTwo = 1 },
				new ClassB() { KeyOne = 5, KeyTwo = 1 }
			};
			
			var l2 = new List<ClassB>()
			{
				new ClassB() { KeyOne = 5, KeyTwo = 0 }
			};
			
			var x = Except(l1, l2).ToList();
			x.Dump();
			
		}
		
		public static IEnumerable<T> Except<T>(IEnumerable<T> items, IEnumerable<T> other)
		{
			var keyProps = typeof(T).GetProperties().Where(prop => prop.IsDefined(typeof(KeyAttribute))).ToList();
			return items.Where(x => !other.Any(o => keyProps.All(prop => prop.GetValue(x).Equals(prop.GetValue(o)))));
		}
	}
	public class ClassB
	{
		[Key]
		public int KeyOne { get; set; }
		
		[Key]
		public int KeyTwo { get; set; }
		
		public string NoKey { get; set; }
	}
