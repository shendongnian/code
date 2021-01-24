    var result = Set.Empty; // Or whatever you use
    
    Tuple<int, int>[] params = {
        new Tuple<int, int>(80, 40),
        new Tuple<int, int>(20, 30),
        // and so on
    }
    
    for(int i = 0; i < N; i++) {
        result.Union(Enumerable.Range(1, 200).Select(x => new Measure { MeasureTypeId = i + 1, Created = DateTime.Now.AddDays(x), Value = (Decimal)(params[i].Item1 * random.NextDouble() + params[i].Item2) }));
    }
    // LINQ version
    var result = Enumerable.Range(1, N).SelectMany(x => Enumerable.Range(1, 200), (t, n) => new Measure {
        MeasureTypeId = t,
        Created = DateTime.Now.AddDays(n),
        Value = (decimal)(params[t - 1].Item1 * random.NextDouble() + params[t - 1].Item2)
    });
