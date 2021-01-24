	public class Foo
	{
		private int _one;
		private int _two;
		
		// simple
		public Foo(int one)
		{
			_one = one; // assign the private field "_one" the value passed in
			_two = 0;   // assign the private field "_two" with a default value of 0
		}
		
		// overloaded (note that the method signature is different)
		public Foo(int one, int two)
		{
			_one = one;
			_two = two;
		}
	}
