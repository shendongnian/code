    var result = Set.Empty; // Or whatever you use
    
    Tuple<int, int>[] params = {
        new Tuple<int, int>(80, 40),
        new Tuple<int, int>(20, 30),
        // and so on
    }
    
    for(int i = 0; i < N; i++) {
        result.Union(Enumerable.Range(1, 200).Select(x => new Measure { MeasureTypeId = i + 1, Created = DateTime.Now.AddDays(x), Value = (Decimal)(params[i].Item1 * random.NextDouble() + params[i].Item2) }));
    }
