	var lockObject = new object();
	var arr = Enumerable.Range(0, 1000000).ToArray();
	long total = 0;
	var min = arr[0];
	var max = arr[0];
	Parallel.For(0, arr.Length,
		() => new Tuple<long, int, int>(0, arr[0], arr[0]),
		(i, loop, temp) => new Tuple<long, int, int>(temp.Item1 + arr[i], Math.Min(temp.Item2, arr[i]),
			Math.Max(temp.Item3, arr[i])),
		x =>
		{
			lock (lockObject)
			{
				total += x.Item1;
				min = Math.Min(min, x.Item2);
				max = Math.Max(max, x.Item3);
			}
		}
	);
