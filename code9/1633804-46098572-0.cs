    var result = Enumerable.Range(3, 17)
        .Concat(Enumerable.Range(10, 10).Select(z => z * 2))
        .Concat(Enumerable.Range(10, 11).Select(z => z * 4))
        .Concat(Enumerable.Range(11, 8).Select(z => z * 8));
    var resultWithNull = new double?[] {null}.Concat(result.Select(z => (double?)z)).ToArray();
