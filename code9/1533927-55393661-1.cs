    void Main()
    {
    
    const int repetitions = 1000000; 
    const string part1 = "Part 1"; 
    const string part2 = "Part 2"; 
    const string part3 = "Part 3"; 
    var vPart1 = GetPart(1); 
    var vPart2 = GetPart(2); 
    var vPart3 = GetPart(3); 
    Test("const string interpolation ", () => $"{part1}{part2}{part3}"); 
    Test("const string concatenation ", () => string.Concat(part1, part2, part3)); 
    Test("const string addition      ", () => part1 + part2 + part3); 
    Test("var string interpolation   ", () => $"{vPart1}{vPart2}{vPart3}"); 
    Test("var string concatenation   ", () => string.Concat(vPart1, vPart2, vPart3)); 
    Test("var string addition        ", () => vPart1 + vPart2 + vPart3); 
    void Test(string info, Func<string> action) 
    { 
        var watch = Stopwatch.StartNew(); 
        for (var i = 0; i < repetitions; i++) 
        { 
            action(); 
        } 
        watch.Stop(); 
        Trace.WriteLine($"{info}: {watch.ElapsedMilliseconds}"); 
    } 
    string GetPart(int index) 
        => $"Part{index}"; 
    }
