	public static class StringExtensions
	{
		public static string Repeat(this string input, int num)
		{
			return String.Concat(Enumerable.Repeat(input, num));
		}
	}
