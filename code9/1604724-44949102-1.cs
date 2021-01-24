    int[][] source = new int[][] {
      new int[] { 1, 2, 3},
      new int[] { 3, 4, 5},
      new int[] { 5, 4, 3},
    };
    int maxCol = source.Max(item => item.Length);
    var colsSum = Enumerable.Range(0, maxCol)
      .Select(index => source.Sum(item => item.Length > index ? item[index] : 0))
      .ToArray(); // let's meaterialize into an array
