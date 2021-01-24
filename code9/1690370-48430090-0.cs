    var s = "[[123,\"0.01\",\"0.02\",\"0.03\",\"0.04\",\"12345.00000\",123456789,\"300.000\",4000,\"123.000\",\"456.000\",\"0\"],[456,\"0.04\",\"0.03\",\"0.02\",\"0.01\",\"54321.00000\",987654321,\"500.000\",4000,\"123.000\",\"456.000\",\"1\"],[789,\"0.05\",\"0.06\",\"0.07\",\"0.08\",\"12345.00000\",123456789,\"700.000\",8000,\"456.000\",\"123.000\",\"0\"]]";
    var lines = s.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries).Select(a => a.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(b => b.TrimEnd('"').TrimStart('"')).ToArray()).Where(a => a.Any());
    var c = lines.Count();
    var foo = new foo
    {
        firstParam = new int[c],
        secondParam = new string[c],
        thirdParam = new string[c]
    };
    for (int i = 0; i < c; i++)
    {
        foo.firstParam[i] = Int32.Parse(lines.ElementAt(i)[0]);
        foo.secondParam[i] = lines.ElementAt(i)[1];
        foo.thirdParam[i] = lines.ElementAt(i)[2];
    }
    Console.WriteLine(string.Join(", ", foo.firstParam)); \\123, 456, 789
    Console.WriteLine(string.Join(", ", foo.secondParam)); \\0.01, 0.04, 0.05
    Console.WriteLine(string.Join(", ", foo.thirdParam)); \\0.02, 0.03, 0.06
