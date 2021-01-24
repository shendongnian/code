    await
		new double[] { 1, 2, 4, 8, 16, 32 }
			.ToObservable()
			.Select(i => Math.Pow(i, 2.0))
			.Do(i => Console.WriteLine("Print: {0}", i))
			.Select(i => i + 1)
			.Select(i => i + 2)
			.ForEachAsync(i => Console.WriteLine("PrintAll: {0}", i));
