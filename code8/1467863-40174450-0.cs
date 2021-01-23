		static void Main(string[] args)
		{
			object obj1 = null;
			object obj2 = "Assigned value";
			Console.WriteLine(string.Format("IsEmpty(obj1) --> {0}", IsEmpty(obj1)));
			Console.WriteLine(string.Format("IsEmpty(obj2) --> {0}", IsEmpty(obj2)));
			Console.ReadLine();
		}
		private static bool IsEmpty<T>(T boxedProperty)
		{
			T defaultProperty = default(T);
			return ReferenceEquals(boxedProperty, defaultProperty);
		}
