	public class Outer
	{
		public int[] IntArray = new[] { 1, 2, 3 };
	
		public class Inner
		{
			public void Draw()
			{
				// ERROR: As the nested class can be instantiated without its parent, it has no way to reference this member.
				IntArray[0] = 0;
			}
		}
	}
