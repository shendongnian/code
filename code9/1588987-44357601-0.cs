    int[] numbers = { 1, 1, 2, 2, 3, 3, 3, 4, 4, 4 };
    var groups = numbers.GroupBy(i => i).OrderByDescending(g => g.Count());
    foreach (var group in groups)
    {
          // group.Key -> Represents the number in the list
    }
