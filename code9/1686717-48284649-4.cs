    String[] lines = coordinates = File.ReadAllLines(path);
    String[][] coordinates = lines.AsParallel().Select(line =>
    {
        String[] parts = line.Split(' ');
        return parts.OrderBy(int.Parse).ToArray();
    }).ToArray();
