    public static void Benchmark1()
    {
        var arr1 = Enumerable.Range(1,10000).ToArray();
        var arr2 = Enumerable.Range(10001,20000).ToArray();
        var arr3 = Enumerable.Range(20001,30000).ToArray();
        var arr4 = Enumerable.Range(30001,40000).ToArray();
        
        var sw = Stopwatch.StartNew();
        var result = arr1.Concat(arr2).Concat(arr3).Concat(arr4).ToArray();
        sw.Stop();
        Console.WriteLine($"Elpased ticks: {sw.ElapsedTicks}");
    }
    public static void Benchmark2()
    {
        var arr1 = Enumerable.Range(1,10000).ToArray();
        var arr2 = Enumerable.Range(10001,20000).ToArray();
        var arr3 = Enumerable.Range(20001,30000).ToArray();
        var arr4 = Enumerable.Range(30001,40000).ToArray();
        
        var arrays = new List<int[]>() {arr1, arr2, arr3, arr4};
        
        var sw = Stopwatch.StartNew();
        
        int finalLen = 0;
        foreach (var arr in arrays)
        {
            finalLen += arr.Length;
        }
        
        var result = new int[finalLen];
        int currentPosition = 0;
        
        foreach (var arr in arrays)
        {
            Array.Copy(arr, 0, result, currentPosition, arr.Length);
            currentPosition += arr.Length;
        }
        
        sw.Stop();
        Console.WriteLine($"Elpased ticks: {sw.ElapsedTicks}");
    }
