    public int[] GetValues(int a, int b, int count)
    {
        double d = (b - a) / (double)(count - 1);
        return Enumerable.Range(0, count)
           .Select(i => (int)Math.Round(a + d * i))
           .ToArray();
    }
    // Usage:
  	int[] r1 = GetValues(1, 10, 10); // 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
	int[] r2 = GetValues(1, 10, 5); // 1, 3, 6, 8, 10
	int[] r3 = GetValues(1, 10, 15); // 1, 2, 2, 3, 4, 4, 5, 6, 6, 7, 7, 8, 9, 9, 10
    
