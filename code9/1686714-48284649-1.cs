    String[] lines = coordinates = File.ReadAllLines(path);
    int[][] coordinates = lines.AsParallel().Select(line =>
    {
        String[] parts = line.Split(' ');
        return parts.Select(int.Parse).ToArray();
    }).OrderBy(coord => coord.Skip(1).Aggregate($"{coord[0]}", (b, c) => $"{b}{c}")).ToArray();
