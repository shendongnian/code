	public class Outer
	{
		public void Draw()
		{
			int[] intArray = new[] { 1, 2, 3 };
		}
	
		public class Inner
		{
			public void Draw()
			{
				// ERROR: The defined array is not available in this scope.
				intArray[0] = 0;
			}
		}
	}
