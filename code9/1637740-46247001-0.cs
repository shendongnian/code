    List<int> ints = new List<int>();
    while (true) {
        var s = Console.ReadLine(s);
        int n;
        if (Int32.TryParse(s, out n)) {
            ints.Add(n);
        } else {
            break;
        }
    }
    int sum = add(ints.ToArray());
