	public class Test
	{
		public IEnumerable<int> ReturnAList()
		{
			Console.WriteLine("ReturnAList called");
			return new List<int>()
			{
				1, 1, 2, 3, 5, 8, 13, 21, 34
			};
		}
	}
