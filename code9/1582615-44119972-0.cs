    private static void TimeMySortAlgorithm(Action<int[]> sortMethod)
	{
		for (int u = 50000; u <= 200000; u += 10000)
		{
			int[] TestArray = new int[u];
			// Rest of the code
            // Invoke the delegate.
			sortMethod(TestArray);
            // Rest of the code
		}
	}
