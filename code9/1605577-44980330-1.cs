    var integerList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    int result = integerList.Where(i => i % 2 == 0)
        .Peek(i => Console.WriteLine(i))
        .First();
    Console.WriteLine(result);
