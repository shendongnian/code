    var array = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
    int count = 0;
    var averages = array.Cast<int>()
                        .GroupBy(x => count++ / array.GetLength(1))
                        .Select(g => g.Average())
                        .ToList();
