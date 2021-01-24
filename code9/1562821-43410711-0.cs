    using System.Collections.Generic;
    using System.Linq;        
    private static void GetMaxPermutation(int max)
    		{
    			var numbers = new[] { 1, 2, 4, 6, 7 };
    			var results = new List<IEnumerable<int>>();
    			for (int i = 0; i < numbers.Length; i++)
    			{
    				results.AddRange(GetPermutations(numbers, i));
    			}
    			Console.WriteLine("Result: " + string.Join(" ", results.Select(x => new { Target = x, Sum = x.Sum() }).Where(x => x.Sum <= max).OrderByDescending(x => x.Sum).FirstOrDefault().Target));
    		}
		private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
		{
			int i = 0;
			foreach (var item in items)
			{
				if (count == 1)
					yield return new T[] { item };
				else
				{
					foreach (var result in GetPermutations(items.Skip(i + 1), count - 1))
						yield return new T[] { item }.Concat(result);
				}
				++i;
			}
		}
