    var test = new TestClass("tiit");
    int factor = 1;
    test.orderedDatas = new[] { 1L, 6L }.OrderBy(i => factor * i);
    Console.WriteLine(JsonConvert.SerializeObject(test, Formatting.Indented));
    factor = -1;
    Console.WriteLine(JsonConvert.SerializeObject(test, Formatting.Indented));
