    var numbers = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
    var results = string.Join(",",
        Enumerable.Range(0, numbers.GetUpperBound(0) + 1)
            .Select(x => Enumerable.Range(0, numbers.GetUpperBound(1) + 1)
                .Select(y => numbers[x, y]))
            .Select(z => "{" + string.Join(",", z) + "}"));
    Console.WriteLine(results);
    Console.ReadLine();
