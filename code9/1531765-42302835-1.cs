	public static IEnumerable<TResult> Select<TInput, TResult>(this IEnumerable<TInput> input,
	   Func<TInput, int, TResult> projectionMapping, int initialAccumulatorValue = -1, int increment = 1)
	{
		var acc = initialAccumulatorValue;
		return input.Select(val => projectionMapping(val, acc += increment));
	}
	var result3 = rows.Select((v, i) => new MyObject(i, v), 0, 10);
