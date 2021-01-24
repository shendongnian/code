    int[] values = new int[1000];
    Random r = new Random();
    for (int i = 0; i < values.Length; i++)
    {
        values[i] = r.Next(1, 30000);
    }
    const int siloCount = 8;
    List<int>[] result = new List<int>[siloCount];
    for (int i = 0; i < siloCount; i++)
    {
        result[i] = new List<int>();
    }
    int[] sums = new int[siloCount];
    int[] indices = Enumerable.Range(0, siloCount).ToArray();
    foreach (int value in values.OrderByDescending(i => i).ToList())
    {
        int siloIndex = indices.First(i => sums[i] == sums.Min());
        sums[siloIndex] += value;
        result[siloIndex].Add(value);
    }
    Debug.WriteLine(String.Join("\r\n", result.Select(s => s.Sum())));
