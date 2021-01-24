    int[][] coordinates = lines.AsParallel().Select(line =>
    {
        String[] parts = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        return parts.Select(int.Parse).ToArray();
    }).Where(line => line.Length > 0).ToArray();
