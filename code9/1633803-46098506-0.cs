    var r = Enumerable.Range(3, 17)
        .Concat(Enumerable.Range(0, 10).Select(i => 20 + i * 2))
        .Concat(Enumerable.Range(0, 10).Select(i => 40 + i * 4))
        .Concat(Enumerable.Range(0, 9).Select(i => 80 + i * 8))
        .ToArray();
