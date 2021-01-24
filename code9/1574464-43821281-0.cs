    class SomeClass
	{
		public SomeClass(List<object> list)
		{
			var enumerator = list.GetEnumerator();
			enumerator.MoveNext();
		}
	}
    class Program
	{
		static void Main(string[] args)
		{
			var list = new List<object>();
			var someClass = Activator.CreateInstance(typeof(SomeClass), 
				new object[] { list = list });
		}
	}
