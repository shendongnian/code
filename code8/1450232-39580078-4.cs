    var inputData = Enumerable.Range(1, 10000)
                                .Select(i => Tuple.Create(10d * i, 1d * i))
                                .ToList();
    { // fastest
        var outputData = new double[inputData.Count, 2];
        var index = 0;
        foreach (var item in inputData)
        {
            outputData[index, 0] = item.Item1;
            outputData[index, 1] = item.Item2;
            index++;
        }
    }
    { // slightly slower
        var outputData = new double[inputData.Count, 2];
        for (var index = inputData.Count - 1; index > -1; index--)
        {
            var tupple = inputData[index];
            outputData[index, 0] = tupple.Item1;
            outputData[index, 1] = tupple.Item2;
        }
    }
    { // much slower
        var outputData = new double[inputData.Count, 2];
        foreach (var item in inputData.Select((v, i) => new { Value = v, Index = i }))
        {
            outputData[item.Index, 0] = item.Value.Item1;
            outputData[item.Index, 1] = item.Value.Item2;
        }
    }
