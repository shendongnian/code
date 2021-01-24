    // Generate some random data
    int[] values = new int[1000];
    Random r = new Random();
    for (int i = 0; i < values.Length; i++)
    {
        values[i] = r.Next(1, 30000);
    }
    // Initialize silos
    const int siloCount = 8;
    List<int>[] result = new List<int>[siloCount];
    for (int i = 0; i < siloCount; i++)
    {
        result[i] = new List<int>();
    }
    int[] sums = new int[siloCount];
    int[] indices = Enumerable.Range(0, siloCount).ToArray();
    // Iterate all values in descending order
    foreach (int value in values.OrderByDescending(i => i).ToList())
    {
        // Find silo with lowest sum (or one of them)
        int siloIndex = indices.First(i => sums[i] == sums.Min());
        // Add to collection and sum - so we don't have to call .Sum() every iteration
        sums[siloIndex] += value;
        result[siloIndex].Add(value);
    }
    Debug.WriteLine(String.Join("\r\n", result.Select(s => s.Sum())));
