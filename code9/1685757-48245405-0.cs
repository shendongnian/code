	void Main()
	{
		var first = new []
		{
			new MyType{Id = 11, Name = "John"},
			new MyType{Id = 12, Name = "Jack"},
			new MyType{Id = 13, Name = "Jim"},
			new MyType{Id = 14, Name = "Joel"},
			new MyType{Id = 15, Name = "Jay"},
		};
	
		var second = new[]
		{
			new MyType{Id = 21, Name = "Jake"},
			new MyType{Id = 22, Name = "Jan"},
			new MyType{Id = 13, Name = "Jim"},
			new MyType{Id = 14, Name = "Joel"},
			new MyType{Id = 23, Name = "Jane"},
			new MyType{Id = 24, Name = "Jade"},
		};
	
		var results = first
			.Union(second)
			.Distinct(new MyTypeComparer());
		results.Dump();
	
		//11 John
		//12 Jack
		//13 Jim
		//14 Joel
		//15 Jay
		//21 Jake
		//22 Jan
		//23 Jane
		//24 Jade
	}
	
	public class MyType
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	
	public class MyTypeComparer : IEqualityComparer<MyType>
	{
		public bool Equals(MyType x, MyType y)
		{
			return x.Id == y.Id;
		}
	
		public int GetHashCode(MyType obj)
		{
			return obj.Id ^ 13;
		}
	}
