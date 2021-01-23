        public static void Main(string[] args)
		{
			int[] x = NthMostCommon(new int[] { 1,2,2,3,3,3,4,4,4,4,5,5,5,5,5,6,6,6,6 }, 2);
			Console.WriteLine(x);
		}
		private static int[] NthMostCommon(int[] a, int k)
		{
			
			var query = a.GroupBy(item => item).GroupBy(g => g.Count())
			             .ToDictionary(x=>x.Key, x=>x.Select(n=>n.Key))
			             .OrderByDescending(g => g.Key);
			if (query.Count() >= k)
			{
				return query.ElementAt(k-1).Value.ToArray();
			}
			return null;
		}
