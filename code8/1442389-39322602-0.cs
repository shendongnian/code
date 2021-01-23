    List<int> integers = new List<int>();
    List<double> doubles = new List<double>();
    for (int i = 0; i < 10; i++)
        doubles.Add(i + new Random().NextDouble());
    foreach (var d in doubles)
    {
        Console.WriteLine(d);
    }
    Console.WriteLine("------------------------");
    integers = doubles.Select(d => (int) d).ToList(); // EVERYTHING IS DONE HERE
    foreach (var i in integers)
    {
        Console.WriteLine(i);
    }
