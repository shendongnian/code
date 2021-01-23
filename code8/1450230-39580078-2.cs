    var inputData = new List<Tuple<double, double>>()
    {
        Tuple.Create(0d,1d),
        Tuple.Create(10d,2d),
        Tuple.Create(20d,3d),
        Tuple.Create(30d,4d),
    };
    var outputData = new double[inputData.Count, 2];
    foreach (var item in inputData.Select((v, i) => new { Value=v, Index=i }))
    {
        outputData[item.Index, 0] = item.Value.Item1;
        outputData[item.Index, 1] = item.Value.Item2;
    }
