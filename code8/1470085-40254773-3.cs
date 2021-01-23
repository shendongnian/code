    const int ListSize = 10000; //change to what you want to measure
    const int Iterations = 1000;
    var list = new List<MyClass>(ListSize);
    for (var i = 0; i < ListSize; i++)
        list.Add(new MyClass());
    //initialize the cached function
    var cachedFunc = GenerateStrExpressionCached<MyClass>("MyProperty");
    var sw = Stopwatch.StartNew();
    for (var i = 0; i < Iterations; i++)
        GenerateStrExpression(list, "MyProperty");
    Console.WriteLine(sw.ElapsedMilliseconds);
    sw.Restart();
    for (var i = 0; i < Iterations; i++)
        GenerateStrReflection(list, "MyProperty");
    Console.WriteLine(sw.ElapsedMilliseconds);
    sw.Restart();
    for (var i = 0; i < Iterations; i++)
        cachedFunc(list);
    Console.WriteLine(sw.ElapsedMilliseconds);
    ...
    class MyClass
    {
        public string MyProperty { get; } = "Hello World";
    }
