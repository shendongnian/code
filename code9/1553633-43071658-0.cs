 		public class Test
		{
			public int Id;
			public string Name;
		}
		public class TestNameComparer : IEqualityComparer<Test>
		{
			public bool Equals(Test x, Test y)
			{
				if (x == null) return y == null;
				return x == y || string.Equals(x.Name, y.Name);
			}
			public int GetHashCode(Test obj)
			{
				return obj.Name.GetHashCode();
			}
		}
