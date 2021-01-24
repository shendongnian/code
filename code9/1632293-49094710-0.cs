    var result = "1.8.0_144";
    var version = new string(result.SkipWhile(c => c != '.')
                                   .Skip(1)
                                   .TakeWhile(c => Char.IsDigit(c))
                                   .ToArray());
    Console.WriteLine(version); // 8
