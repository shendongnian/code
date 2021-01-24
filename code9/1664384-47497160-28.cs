	private int Calculate(int depth)
	{
		try
		{
			if (depth >= _maxDepth)
				throw new InvalidOperationException("Max. recursion depth reached.");
			return Calculate2(depth + 1);
		}
		catch
		{
			if (depth == _maxDepth)
			{
				Console.ReadLine();
			}
			throw;
		}
	}
