        public static void Main(string[] args)
		{
			int[] x = NthMostCommon(new int[] { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5, 6, 6, 6, 6 }, 2);
			Console.WriteLine(x);
		}
		private static int[] NthMostCommon(int[] a, int k)
		{
			var query = GroupAndCount(a)
				.GroupBy(x => x.Value)
				.ToDictionary(x => x.Key, x => x.Select(n => n.Key))
				.OrderByDescending(x => x.Key);
			if (query.Count() >= k)
			{
				return query.ElementAt(k-1).Value.ToArray();
			}
			return null;
		}
		public static IEnumerable<KeyValuePair<T, int>> GroupAndCount<T>
	    (IEnumerable<T> source)
		{
			Dictionary<T, int> dictionary =
				new Dictionary<T, int>();
			foreach (T element in source)
			{
				if (dictionary.ContainsKey(element))
				{
					dictionary[element]++;
				}
				else {
					dictionary[element] = 1;
				}
			}
			return dictionary;
		}
