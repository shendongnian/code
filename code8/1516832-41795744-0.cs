	public class MyClass
	{
		private int field;
        public static implicit operator MyClass(int value)
		{
			return new MyClass { field = value };
		}
	}
