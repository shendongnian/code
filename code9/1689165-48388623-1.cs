    public static IEnumerable<IEnumerable<int>> GroupConsecutive(this IEnumerable<int> source)
    {
        var prev = source.First();
        var grouped = new List<int>(){ prev };
        source = source.Skip(1);
        while (source.Any())
        {
            var current = source.First();
            if (current - prev != 1)
            {
                yield return grouped;
                grouped = new List<int>();
            }
            grouped.Add(current);
            source = source.Skip(1);
            prev = current;
        }
        yield return grouped;
    }
    var numbers = new[] { 1, 2, 3, 4, 6, 7, 9 };
    var result = numbers.GroupConsecutive();
    Output
    1,2,3,4
    6,7
    9
