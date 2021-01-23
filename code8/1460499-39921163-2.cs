    var allStrings = Enumerable.Range(0, 3000000).Select(x => CreateExampleString()).ToList();
    var result1 = Test(ParserBasic, allStrings);
    Console.WriteLine($"Result1: {result1.TotalMilliseconds}ms");
    
    var result2 = Test(parser.ParseVals, allStrings);
    Console.WriteLine($"Result2: {result2.TotalMilliseconds}ms");
    
    var result3 = Test(ParserNoSplit, allStrings);
    Console.WriteLine($"Result3: {result3.TotalMilliseconds}ms");
