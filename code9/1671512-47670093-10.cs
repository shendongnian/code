	public static IEnumerable<T> Yield<T>(this T instance)
	{
		yield return instance;
	}
	public static IEnumerable<IEnumerable<T>> Cartesian<T>(this IEnumerable<IEnumerable<T>> instance)
	{
		var seed = Enumerable.Empty<T>().Yield();
		
		return instance.Aggregate(seed, (accumulator, sequence) =>
		{
			var results = from vector in accumulator
						  from item in sequence
						  select vector.Concat(new[]
						  {
							  item
						  });
			return results;
		});
	}
	public static bool Consecutive(this IEnumerable<int> instance)
	{
		var distinct = instance.Distinct().ToList();
		return distinct
			.Zip(distinct.Skip(1), (a, b) => a + 1 == b)
			.All(p => p);
	}
