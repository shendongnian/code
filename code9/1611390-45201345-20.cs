    var sourceText = "Some test 平仮名, ひらがな string that should be decoded in parallel, this demonstrates that we work flawlessly with Parallel.ForEach. The only downside to using `Parallel.ForEach` the way I demonstrate is that it doesn't take order into account, but oh-well.";
    var source = Encoding.UTF8.GetBytes(sourceText);
    Console.WriteLine(sourceText);
    var results = new ConcurrentBag<string>();
    Parallel.ForEach(GetByteSections(source, 10),
                        new ParallelOptions { MaxDegreeOfParallelism = 1 },
                        x => { Console.WriteLine(Encoding.UTF8.GetString(x)); results.Add(Encoding.UTF8.GetString(x)); });
    Console.WriteLine();
    Console.WriteLine("Assemble the result: ");
    Console.WriteLine(string.Join("", results.Reverse()));
    Console.ReadLine();
