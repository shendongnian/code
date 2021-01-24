	public static int WithParallelLoop(int[] input)
	{
		int result = -1;
		
		Parallel.ForEach
		( 
			input, 
			(element,state) =>
			{
				bool found = false;
				foreach (var n in input)
				{
					if (n == element) found = !found;
				}
				if (found) 
				{
					Interlocked.Exchange(ref result, element);
					state.Stop();
				}
			}
		);
		return result;
	}
