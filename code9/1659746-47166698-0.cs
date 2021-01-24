    var t = new Dictionary<Tuple<char, int, int>, bool>();
    t.Add(new Tuple<char, int, int>('a', 0, 5), false);
    t.Add(new Tuple<char, int, int>('b', 1, 4), true);
    // Prints false
    Console.WriteLine("a, 0, 5 = {0}", t[new Tuple<char, int, int>('a', 0, 5)]);
    // Prints true
    Console.WriteLine("b, 1, 4 = {0}", t[new Tuple<char, int, int>('b', 1, 4)]);
